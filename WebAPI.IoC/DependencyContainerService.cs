﻿using WebAPI.Application.BackgroundServices.RabbitMQ.Consumers;
using WebAPI.Application.Services;
using WebAPI.Domain;
using WebAPI.Domain.Models;
using WebAPI.Infra.Data.Context;
using WebAPI.Infra.Data.Repositories;
using Hangfire;
using KissLog;
using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using KissLog.Formatters;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc.Authorization;
using Microsoft.AspNetCore.RateLimiting;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Serilog;
using Serilog.Filters;
using Serilog.Sinks.MSSqlServer;
using System.Collections.ObjectModel;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Threading.RateLimiting;
using SqlConnection = Microsoft.Data.SqlClient.SqlConnection;
using WebAPI.Application.Generic;
using WebAPI.Application.Factory;
using WebAPI.Application.BackgroundMessageServices.RabbitMQ;
using WebAPI.Domain.Enums;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Domain.Models.EnvVarSettings;
using WebAPI.Domain.Interfaces.Factory;
using WebAPI.Application.Services.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Infra.Repositories.Configuration;
using WebAPI.IoC.Middleware.Authentication;
using WebAPI.Application.InterfacesRepository;
using WebAPI.Infra.Repositories.ControlPanel;
using WebAPI.Domain.Interfaces.Services.NfService;
using WebAPI.Application.Services.NfService;
using WebAPI.Infra.Repositories.Others;
using WebAPI.Application.Services.Graphics;
using System.Text.Json;
using WebAPI.Application.Services.AzureService;
using NPOI.SS.Formula.Functions;
using Confluent.Kafka;
using WebAPI.IoC.Middleware.HealthCheck;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using WebAPI.Application.Services.Tools;

namespace WebAPI.IoC;

public static class DependencyContainerService
{

    #region Metodos Privados

    private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
    {
        // optional KissLog configuration
        options.Options
            .AppendExceptionDetails((Exception ex) =>
            {
                StringBuilder sb = new StringBuilder();

                if (ex is System.NullReferenceException nullRefException)
                {
                    sb.AppendLine("Important: check for null references");
                }

                return sb.ToString();
            });

        // KissLog internal logs
        options.InternalLog = (message) =>
        {
            Debug.WriteLine(message);
        };

        // register logs output
        RegisterKissLogListeners(options, configuration);
    }

    private static void RegisterKissLogListeners(IOptionsBuilder options, IConfiguration configuration)
    {
        options.Listeners.Add(new RequestLogsApiListener(new KissLog.CloudListeners.Auth.Application(
            configuration["KissLog.OrganizationId"],
            configuration["KissLog.ApplicationId"])
        )
        {
            ApiUrl = configuration["KissLog.ApiUrl"]
        });
    }

    private static bool PolicyAreOk(AuthorizationHandlerContext authorizationHandlerContext, PolicyWithClaim policyWithClaim)
    {
        foreach (var itemMultPolicy in policyWithClaim.PoliciesWithClaims)
        {
            if (GuardClauses.IsNullOrWhiteSpace(itemMultPolicy.ClaimValue))
                continue;

            var claimList = itemMultPolicy.ClaimValue.Split(',').ToList();
            var userPermissions = string.Join("", authorizationHandlerContext.User.FindAll(itemMultPolicy.ClaimType).Select(c => c.Value)).Split(',');

            for (int i = 0; i <= userPermissions.Length; i++)
            {
                var userPermission = userPermissions[i];
                if (claimList.Exists(x => x.Equals(userPermission, StringComparison.OrdinalIgnoreCase)))
                    return true;
            }
        }

        return false;
    }

    private static bool PolicyIsOk(AuthorizationHandlerContext authorizationHandlerContext, PolicyWithClaim policyWithClaim)
    {
        if (GuardClauses.IsNullOrWhiteSpace(policyWithClaim.ClaimValue))
            return false;

        var claimList = policyWithClaim.ClaimValue.Split(',').ToList();
        var userPermissions = string.Join("", authorizationHandlerContext.User.FindAll(policyWithClaim.ClaimType).Select(c => c.Value)).Split(',');

        for (int i = 0; i <= userPermissions.Length; i++)
        {
            var userPermission = userPermissions[i];
            if (claimList.Exists(x => x.Equals(userPermission, StringComparison.OrdinalIgnoreCase)))
                return true;
        }

        return false;
    }

    #endregion

    /// <summary>
    /// Essa funcionalidade faz que comandos de inserção/atualização/exclusão sejam agrupados em uma unica viagem de ida e volta ao banco de dados.
    /// Funcionalidade suportada a partir do EF Core
    /// Link de referencia >> https://macoratti.net/22/02/efcore_batind1.htm
    /// </summary>
    /// <param name="MinBatchSize">Valor 5 é recomendado</param>
    /// <param name="MaxBatchSize">Valor entre 20 a 50 é recomendado</param>
    /// <returns></returns>
    public static void RegisterDbConnection(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = EnvironmentVariablesExtension.GetDatabaseFromEnvVar(configuration.GetConnectionString("DefaultConnection"));

        services.AddDbContext<WebAPIContext>(opts =>
        opts.UseSqlServer(connectionString,
        b => b.MinBatchSize(5).MaxBatchSize(50).MigrationsAssembly(typeof(WebAPIContext).Assembly.FullName)).
        LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuting })
        .EnableSensitiveDataLogging());

        // Reutilize o Contexto quando possível (Mais eficiente do que a forma acima..)
        // Referência >> https://macoratti.net/22/10/efc_errevitdesmp1.htm

        //services.AddDbContextPool<WebAPIContext>(opts =>
        //opts.UseSqlServer(connectionString,
        //b => b.MinBatchSize(5).MaxBatchSize(50).MigrationsAssembly(typeof(WebAPIContext).Assembly.FullName)).
        //LogTo(Console.WriteLine, new[] { RelationalEventId.CommandExecuting })
        //.EnableSensitiveDataLogging());

        //Aplica DI para uso do Dapper
        services.AddSingleton<IDbConnection>(provider =>
        {
            var connection = new SqlConnection(connectionString);
            connection.Open();
            return connection;
        });
    }

    public static void RegisterServices(this IServiceCollection services)
    {
        #region UnitOfWork

        services
        .AddScoped<IGenericUnitOfWorkService, GenericUnitOfWorkService>()
        .AddScoped<IGenericNotifyLogsService, GenericNotifyLogsService>()
        .AddScoped<IGenericConfigurationService, GenericConfigurationService>()
        .AddScoped<IGenericUnitofWorkRepository, GenericUnitofWorkRepository>();

        #endregion

        #region Generics

        services
        .AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>))
        .AddScoped(typeof(IGenericRepositoryDapper<>), typeof(GenericRepositoryDapper<>))
        .AddScoped(typeof(IFileService<>), typeof(FileService<>))
        .AddScoped(typeof(IMongoDbService<>), typeof(MongoDbService<>))
        .AddTransient(typeof(IRabbitMQService<>), typeof(RabbitMQService<>));

        #endregion

        #region ControlPanel

        services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<IAccountService, AccountService>();

        #endregion

        #region Configuration

        services
        .AddScoped<IAuthenticationSettingsService, AuthenticationSettingsService>()
        .AddScoped<IEnvironmentTypeSettingsService, EnvironmentTypeSettingsService>()
        .AddScoped<IExpirationPasswordSettingsService, ExpirationPasswordSettingsService>()
        .AddScoped<ILayoutSettingsService, LayoutSettingsService>()
        .AddScoped<ILogSettingsService, LogSettingsService>()
        .AddScoped<IRequiredPasswordSettingsService, RequiredPasswordSettingsService>()
        .AddScoped<IEmailService, EmailService>()
        .AddScoped<IEmailFactory, EmailFactory>()
        .AddScoped<IEmailDisplaySettingsService, EmailDisplaySettingsService>()
        .AddScoped<IEmailSettingsService, EmailSettingsService>()
        .AddScoped<IUploadSettingsService, UploadSettingsService>();

        services
       .AddScoped<IAuthenticationSettingsRepository, AuthenticationSettingsRepository>()
       .AddScoped<IEnvironmentTypeSettingsRepository, EnvironmentTypeSettingsRepository>()
       .AddScoped<IExpirationPasswordSettingsRepository, ExpirationPasswordSettingsRepository>()
       .AddScoped<ILayoutSettingsRepository, LayoutSettingsRepository>()
       .AddScoped<ILogSettingsRepository, LogSettingsRepository>()
       .AddScoped<IRequiredPasswordSettingsRepository, RequiredPasswordSettingsRepository>()
       .AddScoped<IEmailDisplaySettingsRepository, EmailDisplaySettingsRepository>()
       .AddScoped<IEmailSettingsRepository, EmailSettingsRepository>()
       .AddScoped<IUploadSettingsRepository, UploadSettingsRepository>();

        #endregion

        services
        .AddScoped<IAddressRepository, AddressRepository>()
        .AddScoped<ICityRepository, CityRepository>()
        .AddScoped<IRegionRepository, RegionRepository>()
        .AddScoped<IStatesRepository, StateRepository>()
        .AddScoped<ILogRepository, LogRepository>()
        .AddScoped<IAuditRepository, AuditRepository>()
        .AddScoped<INotificationMessageService, NotificationMessageService>()
        .AddScoped<IAuditService, AuditService>()
        .AddScoped<IAddressService, AddressService>()
        .AddScoped<ICityService, CityService>()
        .AddScoped<ILogService, LogService>()
        .AddScoped<IGeneralLogService, GeneralLogService>()
        .AddScoped<IGeneralService, GeneralService>()
        .AddScoped<IRegionService, RegionService>()
        .AddScoped<IStatesService, StatesService>()
        .AddScoped<IGraphicLineService, GraphicLineService>()
        .AddScoped<IGraphicBarService, GraphicBarService>()
        .AddScoped<IQRCodeService, QRCodeService>()
        .AddScoped<IMemoryCacheService, MemoryCacheService>()
        .AddTransient<IIpAddressService, IpAddressService>()
        .AddScoped<INfService, NfService>()
        .AddScoped<IFirebaseService, FirebaseService>()
        .AddTransient<IProblemDetailsFactory, ProblemDetailsFactory>()
        .AddScoped<ISendGridService, SendGridService>()
        .AddScoped<IAzureService, AzureService>();
    }

    public static void RegisterMapperConfig(this IServiceCollection services)
    {
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
    }

    public static void RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        var tokenConfiguration = new TokenSettings();
        configuration.Bind("TokenSettings", tokenConfiguration);
        services.AddSingleton(tokenConfiguration);

        var cacheConfiguration = new CacheSettings();
        configuration.Bind("CacheSettings", cacheConfiguration);
        services.AddSingleton(cacheConfiguration);

        var connectionStringSettings = new ConectionStringSettings();
        configuration.Bind("ConnectionStrings", connectionStringSettings);
        services.AddSingleton(connectionStringSettings);
    }

    public static void RegisterPolicy(this IServiceCollection services)
    {
        services.AddMvcCore(config =>
        {
            var policy = new AuthorizationPolicyBuilder()
                .RequireAuthenticatedUser()
                .Build();

            config.Filters.Add(new AuthorizeFilter(policy));
        }).AddApiExplorer();
    }

    public static void RegisterCorsConfigRestriction(this IServiceCollection services, IConfiguration configuration)
    {
        var origins = EnvironmentVariablesExtension.GetEnvironmentVariableToStringArray<string[]>(configuration, "WebAPI_Settings:corsSettings");
        services.AddCors(options =>
        {
            options.AddPolicy("EnableCORS", builder =>
            {
                builder
                .WithOrigins(origins) // Configuração de sites que tem permissão para acessar a API
                .WithMethods("GET", "POST", "PUT", "DELETE") // Configuração de tipos de metodos que serão liberados para consumo GET, POST, PUT, DELETE
                .SetIsOriginAllowed((host) => true)
                .AllowAnyOrigin()
                .AllowAnyHeader();
            });
        });
    }

    public static void RegisterCorsConfigNoRestriction(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddCors(options =>
        {
            options.AddPolicy("EnableCORS", builder =>
            {
                builder
                .SetIsOriginAllowed((host) => true)
                .AllowAnyMethod()
                .AllowAnyHeader()
                .AllowCredentials();
            });
        });
    }

    public static void RegisterJwtConfig(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddAuthentication
              (x =>
              {
                  x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                  x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
              })
              .AddJwtBearer(options =>
              {
                  options.RequireHttpsMetadata = false;
                  options.SaveToken = true;
                  options.TokenValidationParameters = new TokenValidationParameters
                  {
                      ValidateIssuer = false,
                      ValidateAudience = false,
                      ValidateLifetime = true,
                      ValidateIssuerSigningKey = true,
                      ClockSkew = TimeSpan.Zero,
                      ValidIssuer = configuration["TokenSettings:Issuer"],
                      ValidAudience = configuration["TokenSettings:Audience"],
                      IssuerSigningKey = new SymmetricSecurityKey
                      (Encoding.UTF8.GetBytes(configuration["TokenSettings:Key"]))
                  };
              });

        services.AddAuthorization(auth =>
        {
            auth.AddPolicy("Bearer", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                .RequireAuthenticatedUser()
                .Build());

            auth.AddPolicy("BearerRole", new AuthorizationPolicyBuilder()
                .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme)
                .RequireAuthenticatedUser()
                .RequireClaim("Admin")
                .Build());
        });
    }

    public static void RegisterHttpClientConfig(this IServiceCollection services)
    {
        #region Versão Depreciada de configuração do HTTPClient

        //services.AddHttpClient("Signed").ConfigureHttpMessageHandlerBuilder(builder =>
        //{
        //    builder.PrimaryHandler = new HttpClientHandler
        //    {
        //        ServerCertificateCustomValidationCallback = (m, c, ch, e) => true
        //    };
        //});

        #endregion

        services.AddHttpClient("Signed").ConfigurePrimaryHttpMessageHandler(() =>
        {
            return new HttpClientHandler
            {
                ServerCertificateCustomValidationCallback = (message, cert, chain, errors) => true
            };
        });
    }

    public static IServiceCollection RegisterMediator(this IServiceCollection services)
    {
        var myAssembly = AppDomain.CurrentDomain.Load("WebAPI.Application");
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssemblies(myAssembly));
        return services;
    }

    public static IServiceCollection RegisterKissLog(this IServiceCollection services)
    {
        // Optional. Register IKLogger if you use KissLog.IKLogger instead of Microsoft.Extensions.Logging.ILogger<>
        services.AddSingleton<IKLogger>((provider) => Logger.Factory.Get());

        services.AddLogging(logging =>
        {
            logging.AddKissLog(options =>
            {
                options.Formatter = (FormatterArgs args) =>
                {
                    if (GuardClauses.ObjectIsNull(args.Exception))
                        return args.DefaultValue;

                    string exceptionStr = new ExceptionFormatter().Format(args.Exception, args.Logger);

                    return string.Join(Environment.NewLine, new[] { args.DefaultValue, exceptionStr });
                };
            });
        });

        return services;
    }

    public static IApplicationBuilder UseKissLog(this IApplicationBuilder app, IConfiguration configuration)
    {
        app.UseKissLogMiddleware(options =>
        {
            ConfigureKissLog(options, configuration);
        });

        return app;
    }

    public static void RegisterCustomAuthorizeConfig(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultScheme = CustomMyAuthenticationSchemeOptions.SchemeName;
            options.DefaultAuthenticateScheme = CustomMyAuthenticationSchemeOptions.SchemeName;
            options.DefaultChallengeScheme = CustomMyAuthenticationSchemeOptions.SchemeName;
        }).AddScheme<CustomMyAuthenticationSchemeOptions, CustomAuthorizeHandler>(CustomMyAuthenticationSchemeOptions.SchemeName, options =>
        {
            options.PoliciesWithClaims = CustomMyAuthenticationSchemeOptions.GetPolicies();
        });

        services.AddAuthorization(options =>
        {
            //Quando e para validar somente uma regra especifica, usa isso
            //options.AddPolicy("GetProfileByFiltersPolicy", policy => policy.RequireClaim(EClaim.ProfileConsulta.GetDescription(), "read"));

            //Quando e mais ação, porem tendo uma delas ja e valido
            foreach (var item in CustomMyAuthenticationSchemeOptions.GetPolicies())
            {
                options.AddPolicy(item.PolicyName, policy =>
                {
                    policy.RequireAuthenticatedUser();

                    policy.RequireAssertion(context =>
                    {
                        if (item.HasMultiplePolicies)
                        {
                            return PolicyAreOk(context, item);
                        }

                        return PolicyIsOk(context, item);
                    });
                });
            }
        });
    }

    public static void RegisterHangFireConfig(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionString = EnvironmentVariablesExtension.GetDatabaseFromEnvVar(configuration.GetConnectionString("DefaultConnection"));

        services.AddHangfire(x => x.UseSimpleAssemblyNameTypeSerializer()
                                   .UseRecommendedSerializerSettings()
                                   .UseSqlServerStorage(connectionString));
        services.AddHangfireServer();
    }

    /// <summary>
    /// È um cliente Redis mais simples e facil de configurar. Ideal para integrações mais simples (Microsoft.Extensions.Caching.Redis)
    /// È um cliente Redis mais poderoso e robusto, criado e mantido pela StackExchange. Ideal para integrações mais robustas (Microsoft.Extensions.Caching.StackExchangeRedis)
    /// </summary>
    /// <param name="services"></param>
    /// <param name="configuration"></param>
    /// <returns></returns>
    public static IServiceCollection RegisterRedis(this IServiceCollection services, IConfiguration configuration)
    {
        #region Versão Depreciada de conexão do REDIS

        //services.AddDistributedRedisCache(options =>
        //{
        //    options.Configuration = "localhost:6379";
        //    options.InstanceName = "DATABASE - ";
        //});

        #endregion

        services.AddStackExchangeRedisCache(options =>
        {
            options.Configuration = "localhost:6379";
            options.InstanceName = "DATABASE - ";
        });

        return services;
    }

    public static IServiceCollection RegisterGlobalRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        int totalRequestPermit = 10;
        TimeSpan timePerRequest = TimeSpan.FromMinutes(1);

        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.GlobalLimiter = PartitionedRateLimiter.Create<HttpContext, string>(httpContext =>
            RateLimitPartition.GetFixedWindowLimiter(
                partitionKey: httpContext.User.Identity?.Name ??
                              httpContext.Request.Headers.Host.ToString(),
                factory: partition => new FixedWindowRateLimiterOptions
                {
                    AutoReplenishment = true,
                    PermitLimit = totalRequestPermit,
                    QueueLimit = 0,
                    Window = timePerRequest
                }));

            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;

                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsync(
                    $"Muitos requests feitos. Tente novamente depois " +
                    $"de {retryAfter.TotalMinutes} minuto(s). \n\n",
                    cancellationToken: token
                    );
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync(
                    $"Muitos requests feitos. Tente novamente depois " +
                    $"de {retryAfter.TotalMinutes} minuto(s). \n\n",
                    cancellationToken: token
                    );
                }
            };
        });

        return services;
    }

    public static IServiceCollection RegisterPolicyRateLimiting(this IServiceCollection services, IConfiguration configuration)
    {
        // Nos Endpoints dos controllers, utilizar o atributo [EnableRateLimiting("NOME_DA_POLITICA")]
        // Pode-se ter 1 ou N Politicas, sendo casa uma com um nome especifico

        int totalRequestPermit = 10;
        TimeSpan timePerRequest = TimeSpan.FromMinutes(1);

        services.AddRateLimiter(options =>
        {
            options.RejectionStatusCode = StatusCodes.Status429TooManyRequests;

            options.AddFixedWindowLimiter(policyName: "API_RATE_LIMIT", options =>
            {
                options.AutoReplenishment = true;
                options.PermitLimit = totalRequestPermit;
                options.Window = timePerRequest;
                options.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
                options.QueueLimit = 0;
            });

            options.OnRejected = async (context, token) =>
            {
                context.HttpContext.Response.StatusCode = 429;

                if (context.Lease.TryGetMetadata(MetadataName.RetryAfter, out var retryAfter))
                {
                    await context.HttpContext.Response.WriteAsync(
                    $"Muitos requests feitos. Tente novamente depois " +
                    $"de {retryAfter.TotalMinutes} minuto(s). \n\n",
                    cancellationToken: token
                    );
                }
                else
                {
                    await context.HttpContext.Response.WriteAsync(
                    $"Muitos requests feitos. Tente novamente depois " +
                    $"de {retryAfter.TotalMinutes} minuto(s). \n\n",
                    cancellationToken: token
                    );
                }
            };
        });

        return services;
    }

    #region Configuração do serviço Serilog

    public static void RegisterSeriLog(this IServiceCollection services, IConfiguration configuration)
    {
        var connectionStringLogs = EnvironmentVariablesExtension.GetDatabaseFromEnvVar(configuration.GetConnectionString("DefaultConnectionLogs"));

        Serilog.Debugging.SelfLog.Enable(msg => Console.WriteLine(msg));

        Serilog.Log.Logger = new LoggerConfiguration()
            .Enrich.WithProperty("CreatedDate", DateTime.Now)
            .Filter.ByIncludingOnly(Matching.WithProperty("Object"))
            .WriteTo.MSSqlServer(connectionString: connectionStringLogs,
            sinkOptions: new Serilog.Sinks.MSSqlServer.MSSqlServerSinkOptions
            {
                AutoCreateSqlDatabase = false,
                AutoCreateSqlTable = true,
                TableName = "Logs",
                SchemaName = "dbo",
            },
            columnOptions: GetSqlColumnOptions()

            ).CreateLogger();

        services.AddSingleton(Serilog.Log.Logger);
    }

    public static ColumnOptions GetSqlColumnOptions()
    {
        var colOptions = new ColumnOptions();
        colOptions.Store.Remove(StandardColumn.Properties);
        colOptions.Store.Remove(StandardColumn.MessageTemplate);
        colOptions.Store.Remove(StandardColumn.Message);
        colOptions.Store.Remove(StandardColumn.Exception);
        colOptions.Store.Remove(StandardColumn.TimeStamp);

        colOptions.AdditionalColumns = new Collection<SqlColumn>
        {
            new SqlColumn{ DataType = SqlDbType.VarChar, ColumnName = "Class", DataLength = 100, AllowNull = true},
            new SqlColumn{ DataType = SqlDbType.VarChar, ColumnName = "Method", DataLength = 100, AllowNull = true},
            new SqlColumn{ DataType = SqlDbType.VarChar, ColumnName = "MessageError", DataLength = 2000, AllowNull = true},
            new SqlColumn{ DataType = SqlDbType.VarChar, ColumnName = "Object", AllowNull = true},
            new SqlColumn{ DataType = SqlDbType.DateTime, ColumnName = "CreatedDate", AllowNull = false},
        };

        return colOptions;
    }

    #endregion

    public static void RegisterEnvironmentVariables(this IServiceCollection services, IConfiguration configuration)
    {
        if (!EnvironmentVariables.LoadEnvironmentVariables(configuration))
        {
            throw new ApplicationException("Application End. Erro: Váriaveis de ambiente ausentes.");
        }

        var data = EnvironmentVariablesExtension.GetEnvironmentVariablesList(configuration);

        Action<EnvironmentVariables> resultValues = (opt =>
        {
            #region Variavel do JSON da APP
            opt.ConnectionStringSettings.DefaultConnection = data["WebAPI_Sql"];
            opt.ConnectionStringSettings.DefaultConnectionLogs = data["WebAPI_Logs"];
            opt.ConnectionStringSettings.DefaultConnectionToDocker = data["WebAPI_Docker"];
            if (data["WebAPI_RabbitMQ"] != null)
            {
                opt.RabbitMQSettings = JsonSerializer.Deserialize<RabbitMQSettings>(data["WebAPI_RabbitMQ"]);
            }
            opt.KafkaSettings = JsonSerializer.Deserialize<KafkaSettings>(data["WebAPI_Kafka"]);
            opt.ServiceBusSettings = JsonSerializer.Deserialize<ServiceBusSettings>(data["WebAPI_ServiceBus"]);
            opt.SendGridSettings = JsonSerializer.Deserialize<SendGridSettings>(data["WebAPI_SendGrid"]);
            Enum.TryParse(data["WebAPI_Environment"], out EnumEnvironment environment);
            opt.Environment = environment;
            #endregion
        });

        services.Configure(resultValues);
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EnvironmentVariables>>().Value);
    }

    public static void RegisterBackGroundServices(this IServiceCollection services)
    {
        // Execução de consumer do rabbitMQ em background da APP
        services.AddHostedService<ExcelBackGroundService>();
    }

    public static void RegisterHealthCheck(this IServiceCollection services, IConfiguration configuration)
    {
        #region Itens que podem ser monitorados

        //AddAzureServiceBusQueue
        //AddAzureBlobStorage
        //.AddHangfire(options => { options.MinimumAvailableServers = 1; }, name: "Jobs", failureStatus: HealthStatus.Unhealthy, tags: new[] { "HangFire" })
        //.AddMongoDb(connectionStringMongoDb, name: "Banco de dados Mongo", tags: new string[] { "db", "data" });
        //.AddKafka(configKafka, name: "Serviço de mensageria Kafka", tags: new string[] { "queue", "data" })
        //.AddSendGrid(apiKey: connectionServiceSendGrid.ApiKey, name: "Serviço de SendGrid", failureStatus: HealthStatus.Unhealthy, tags: new string[] { "sendGrid" });

        #endregion

        var TAG_NAME = "PROD";

        var connectionStringSQLServerLog = EnvironmentVariablesExtension.GetDatabaseFromEnvVar(configuration.GetConnectionString("DefaultConnectionLogs"));
        var connectionServiceRabbitMQ = JsonSerializer.Deserialize<RabbitMQSettings>(EnvironmentVariablesExtension.GetEnvironmentVariable(("WebAPI_RabbitMQ")));

        services
       .AddHealthChecks()
       .AddDbContextCheck<WebAPIContext>(name: "Banco de dados", failureStatus: HealthStatus.Unhealthy, tags: new string[] { TAG_NAME })
       .AddSqlServer(connectionStringSQLServerLog, name: "Banco de dados LOGS", failureStatus: HealthStatus.Unhealthy, tags: new string[] { TAG_NAME })
       .AddRabbitMQ($"amqp://{connectionServiceRabbitMQ.UserName}:{connectionServiceRabbitMQ.Password}@{connectionServiceRabbitMQ.HostName}:5672/", name: "Serviço de mensageria RabbitMQ", failureStatus: HealthStatus.Unhealthy, tags: new string[] { TAG_NAME })
       .AddCheck<CustomWebAppHealthCheck>(name: "Aplicação Web", failureStatus: HealthStatus.Unhealthy, tags: new[] { TAG_NAME })
       .AddCheck<CustomKissLogHealthCheck>(name: "Serviço de KissLog", failureStatus: HealthStatus.Unhealthy, tags: new string[] { TAG_NAME })
       .AddRedis("localhost:6379", name: "Banco de dados REDIS", failureStatus: HealthStatus.Unhealthy, tags: new string[] { TAG_NAME });
    }

    public static void RegisterHealthCheckDashboard(this IServiceCollection services)
    {
        services.AddHealthChecksUI(options =>
        {
            options.SetEvaluationTimeInSeconds(10);
            options.MaximumHistoryEntriesPerEndpoint(10);
            options.AddHealthCheckEndpoint("Monitoramento de serviços da Aplicação WEBAPI", "/health");
        })
        .AddInMemoryStorage();
    }

    public static void RegisterSignalR(this IServiceCollection services)
    {
        services.AddSignalR();
    }
}
