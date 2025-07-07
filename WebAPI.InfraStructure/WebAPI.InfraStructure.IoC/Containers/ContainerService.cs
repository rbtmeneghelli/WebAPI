using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System.Data;
using System.Diagnostics;
using System.Text;
using System.Text.Json;
using Microsoft.Extensions.Diagnostics.HealthChecks;
using KissLog.AspNetCore;
using KissLog.CloudListeners.RequestLogsListener;
using WebAPI.Domain;
using WebAPI.Infrastructure.CrossCutting.Middleware.Authentication;
using WebAPI.InfraStructure.Data.Context;
using WebAPI.Domain.Interfaces.Repository;
using WebAPI.Application.Generic;
using KissLog;
using KissLog.Formatters;
using WebAPI.Domain.Enums;
using WebAPI.Infrastructure.CrossCutting.BackgroundServices;
using WebAPI.Infrastructure.CrossCutting.Middleware.HealthCheck;
using WebAPI.Domain.Interfaces.Services.Tools;
using WebAPI.InfraStructure.Data.Repositories;
using WebAPI.InfraStructure.Data.Repositories.Others;
using WebAPI.Application.Services.Tools;
using WebAPI.Application.Services;
using WebAPI.Domain.Interfaces.Services;
using WebAPI.Application.Services.Graphics;
using WebAPI.Domain.Models;
using WebAPI.Application.Services.Configuration;
using WebAPI.Domain.Interfaces.Repository.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;
using WebAPI.Application.InterfacesRepository;
using WebAPI.InfraStructure.Data.Repositories.ControlPanel;
using WebAPI.InfraStructure.Data.Repositories.Configuration;
using WebAPI.Application.Factory;
using WebAPI.Domain.Interfaces.Factory;
using ProblemDetailsFactory = WebAPI.Application.Factory.ProblemDetailsFactory;
using WebAPI.Domain.Interfaces.Generic;
using Microsoft.AspNetCore.ResponseCompression;
using WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ.Consumers;
using WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ;
using WebAPI.Domain.Interfaces.Services.Charts;
using FastPackForShare.Extensions;
using FastPackForShare.Models;
using FluentValidation;

namespace WebAPI.InfraStructure.IoC.Containers;

public static class ContainerService
{

    #region Metodos Privados

    private static void ConfigureKissLog(IOptionsBuilder options, IConfiguration configuration)
    {
        // optional KissLog configuration
        options.Options
            .AppendExceptionDetails((Exception ex) =>
            {
                StringBuilder sb = new StringBuilder();

                if (ex is NullReferenceException nullRefException)
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
            if (GuardClauseExtension.IsNullOrWhiteSpace(itemMultPolicy.ClaimValue))
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
        if (GuardClauseExtension.IsNullOrWhiteSpace(policyWithClaim.ClaimValue))
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
        .AddScoped(typeof(IGenericReadRepository<>), typeof(GenericReadRepository<>))
        .AddScoped(typeof(IGenericWriteRepository<>), typeof(GenericWriteRepository<>))
        .AddScoped(typeof(IGenericReadDapperRepository<>), typeof(GenericReadDapperRepository<>))
        .AddScoped<IGenericWriteDapperRepository,GenericWriteDapperRepository>()
        .AddTransient(typeof(IRabbitMQService<>), typeof(RabbitMQService<>));

        #endregion

        #region ControlPanel

        services
        .AddScoped<IUserRepository, UserRepository>()
        .AddScoped<IUserService, UserService>()
        .AddScoped<IAccountService, AccountService>();

        #endregion

        #region Factory

        services
        .AddScoped<IGraphicFactory, GraphicFactory>()
        .AddScoped<IEmailFactory, EmailFactory>();

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

        _ = services
        .AddScoped<IAddressRepository, AddressRepository>()
        .AddScoped<ICityRepository, CityRepository>()
        .AddScoped<IRegionRepository, RegionRepository>()
        .AddScoped<IStatesRepository, StateRepository>()
        .AddScoped<ILogRepository, LogRepository>()
        .AddScoped<IAuditRepository, AuditRepository>()
        .AddScoped<IAuditService, AuditService>()
        .AddScoped<IAddressService, AddressService>()
        .AddScoped<ICityService, CityService>()
        .AddScoped<ILogService, LogService>()
        .AddScoped<IGeneralLogService, GeneralLogService>()
        .AddScoped<IGeneralService, GeneralService>()
        .AddScoped<IRegionService, RegionService>()
        .AddScoped<IStatesService, StatesService>()
        .AddScoped<IGraphicChartJSService, GraphicChartJSService>()
        .AddScoped<IGraphicGoogleChartService, GraphicGoogleChartService>()
        .AddScoped<IFirebaseService, FirebaseService>()
        .AddTransient<IProblemDetailsFactory, ProblemDetailsFactory>()
        .AddScoped<ISendGridService, SendGridService>();
    }

    public static void RegisterConfigs(this IServiceCollection services, IConfiguration configuration)
    {
        var cacheConfiguration = new MemoryCacheModel();
        configuration.Bind("CacheSettings", cacheConfiguration);
        services.AddSingleton(cacheConfiguration);

        var connectionStringSettings = new ConectionStringSettings();
        configuration.Bind("ConnectionStrings", connectionStringSettings);
        services.AddSingleton(connectionStringSettings);
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
                    if (GuardClauseExtension.IsNull(args.Exception))
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

    public static void RegisterEnvironmentVariables(this IServiceCollection services, IConfiguration configuration)
    {
        if (!EnvironmentVariables.LoadEnvironmentVariables(configuration))
        {
            throw new ApplicationException("Application End. Erro: Váriaveis de ambiente ausentes.");
        }

        var data = EnvironmentVariablesExtension.GetEnvironmentVariablesList(configuration);

        Action<EnvironmentVariables> resultValues = opt =>
        {
            #region Variavel do JSON da APP
            opt.ConnectionStringSettings.DefaultConnection = data["WebAPI_Sql"];
            opt.ConnectionStringSettings.DefaultConnectionLogs = data["WebAPI_Logs"];
            opt.ConnectionStringSettings.DefaultConnectionToDocker = data["WebAPI_Docker"];
            if (data["WebAPI_RabbitMQ"] != null)
            {
                opt.RabbitMQSettings = JsonSerializer.Deserialize<RabbitMQModel>(data["WebAPI_RabbitMQ"]);
            }
            opt.KafkaSettings = JsonSerializer.Deserialize<KafkaModel>(data["WebAPI_Kafka"]);
            opt.ServiceBusSettings = JsonSerializer.Deserialize<ServiceBusSettings>(data["WebAPI_ServiceBus"]);
            opt.SendGridSettings = JsonSerializer.Deserialize<SendGridConfigModel>(data["WebAPI_SendGrid"]);
            Enum.TryParse(data["WebAPI_Environment"], out EnumEnvironment environment);
            opt.Environment = environment;
            opt.JwtConfigSettings = JsonSerializer.Deserialize<JwtConfigModel>(data["WebAPI_Token"]);
            #endregion
        };

        services.Configure(resultValues);
        services.AddSingleton(resolver => resolver.GetRequiredService<IOptions<EnvironmentVariables>>().Value);
    }

    public static void RegisterBackGroundServices(this IServiceCollection services)
    {
        // Execução de consumer do rabbitMQ em background da APP
        services.AddHostedService<ExcelBackGroundService>();
        services.AddHostedService<FreshContextInstanceBackgroundService>();
    }

    public static void RegisterHealthCheck(this IServiceCollection services, EnvironmentVariables environmentVariables)
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

        var connectionStringSQLServerLog = environmentVariables.ConnectionStringSettings.DefaultConnectionLogs;
        var connectionServiceRabbitMQ = environmentVariables.RabbitMQSettings;

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

    public static void RegisterDataCompress(this IServiceCollection services)
    {
        services.AddResponseCompression(options =>
        {
            options.EnableForHttps = true;
            options.Providers.Add<BrotliCompressionProvider>();
            options.Providers.Add<GzipCompressionProvider>();
            // Restringir a compactação dos dados somente para JSON ou algum outro tipo de formatação
            // options.MimeTypes = ResponseCompressionDefaults.MimeTypes.Concat(new[] { "application/json" }); 
        });
    }

    public static void RegisterOAuth(this IServiceCollection services)
    {
        services.AddAuthentication(options =>
        {
            options.DefaultAuthenticateScheme = "OAuth";
            options.DefaultChallengeScheme = "OAuth";
        })
        .AddOAuth("OAuth", options =>
        {
            options.ClientId = "seu_client_id";
            options.ClientSecret = "seu_client_secret";
            options.CallbackPath = "/oauth/callback";
            options.AuthorizationEndpoint = "URL_do_endpoint_de_autorizacao";
            options.TokenEndpoint = "URL_do_endpoint_de_token";
            options.SaveTokens = true;
            // Configurações adicionais específicas do provedor OAuth
        });
    }

    public static void RegisterFluentValidation(this IServiceCollection services)
    {
        var myAssembly = AppDomain.CurrentDomain.Load("WebAPI.Domain");
        services.AddValidatorsFromAssembly(myAssembly);
    }
}
