using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebAPI.InfraStructure.IoC.Containers;
using WebAPI.InfraStructure.Data.Context;
using WebAPI.Infrastructure.CrossCutting.Middleware.ExceptionHandler;
using FastPackForShare.Containers;

public class WebAPIContextFactory : IDesignTimeDbContextFactory<WebAPIContext>
{
    /// <summary>
    /// Se for necessario, remover <PrivateAssets>all</PrivateAssets> da referência ao pacote Microsoft.EntityFrameworkCore.Design no arquivo de projeto. Assim a referência a este pacote ficou definida assim:
    /// <PackageReference Include = "Microsoft.EntityFrameworkCore.Design" Version="5.0.3">
    /// <IncludeAssets>runtime; build; native; contentfiles; analyzers; buildtransitive</IncludeAssets>
    /// </PackageReference>
    /// </summary>
    /// <param name="args"></param>
    /// <returns></returns>
    public WebAPIContext CreateDbContext(string[] args)
    {
        IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddJsonFile("appsettings.json")
            .Build();

        var builder = new DbContextOptionsBuilder<WebAPIContext>();
        var connectionString = EnvironmentVariablesExtension.GetDatabaseFromEnvVar(configuration.GetConnectionString("DefaultConnection"));
        builder.UseSqlServer(connectionString);

        return new WebAPIContext(builder.Options);
    }
}

public class Startup
{
    private readonly IHostEnvironment _environment;
    private readonly IConfiguration _configuration;

    public Startup(IHostEnvironment environment)
    {
        var configApp = new ConfigurationBuilder().SetBasePath(environment.ContentRootPath)
        .AddJsonFile("appsettings.json", optional: true, reloadOnChange: true)
        .AddEnvironmentVariables()
        .Build();

        _configuration = configApp;
        _environment = environment;
    }

    public void ConfigureServices(IServiceCollection services)
    {
        // Utilizar dessa forma, caso seja feita de parte a parte, ao inves de integral
        // Add functionality to inject IOptions<T> (Fazer o IOptions<T> na controller)
        // services.AddOptions();

        ContainerFastPackForShareServices.RegisterDbConnection<WebAPIContext>(services, 
                                                                              EnvironmentVariablesExtension.GetDatabaseFromEnvVar(_configuration.GetConnectionString("DefaultConnection")));
        ContainerFastPackForShareServices.RegisterServices(services);
        ContainerFastPackForShareServices.RegisterCors(services, 
                                                       EnvironmentVariablesExtension.GetEnvironmentVariableToStringArray<string[]>(_configuration, "WebAPI_Settings:corsSettings"),
                                                       "APICORS");
        ContainerFastPackForShareServices.RegisterHttpClient(services);
        ContainerFastPackForShareServices.RegisterHttpContextAccessor(services);
        ContainerFastPackForShareServices.RegisterProblemDetails(services);
        ContainerFastPackForShareServices.RegisterMemoryCache(services);
        ContainerFastPackForShareServices.RegisterMediator(services, "WebAPI.Application");
        ContainerFastPackForShareServices.RegisterSimpleMediator(services, "WebAPI.Application");
        ContainerFastPackForShareServices.RegisterAutoMapper(services, AppDomain.CurrentDomain.GetAssemblies());
        ContainerFastPackForShareServices.RegisterPolicy(services);

        ContainerService.RegisterServices(services);
        ContainerService.RegisterConfigs(services, _configuration);
        ContainerService.RegisterFluentValidation(services);
        ContainerSwagger.RegisterJwtTokenEncryptConfig(services, _configuration);
        ContainerSwagger.RegisterSwaggerConfig(services);

        services.AddControllers().AddViewOptions(options =>
        {
            options.HtmlHelperOptions.ClientValidationEnabled = true;
        });

        services.AddApiVersioning(options =>
        {
            options.ReportApiVersions = true;
            options.AssumeDefaultVersionWhenUnspecified = true;
            options.DefaultApiVersion = new ApiVersion(1, 0);
        });

        services.AddVersionedApiExplorer(options =>
        {
            options.GroupNameFormat = "'v'VV";
            options.SubstituteApiVersionInUrl = true;

        });

        services.Configure<ApiBehaviorOptions>(options =>
        {
            options.SuppressModelStateInvalidFilter = true;
        });

        services.RegisterEnvironmentVariables(_configuration);

        services.AddExceptionHandler<GlobalExceptionHandler>();
        ContainerService.RegisterHealthCheck(services, _configuration);
        ContainerService.RegisterHealthCheckDashboard(services);
        ContainerService.RegisterSignalR(services);

    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        ContainerApp.UseAppConfig(app, env, configuration);
        ContainerSwagger.UseSwaggerConfig(app, provider);
    }
}

