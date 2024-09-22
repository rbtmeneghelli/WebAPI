using Microsoft.AspNetCore.Mvc.ApiExplorer;
using WebAPI.IoC;
using WebAPI.IoC.Middleware.ExceptionHandler;


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

        DependencyContainerService.RegisterDbConnection(services, _configuration);
        DependencyContainerService.RegisterServices(services);
        DependencyContainerService.RegisterMapperConfig(services);
        DependencyContainerService.RegisterConfigs(services, _configuration);
        DependencyContainerService.RegisterPolicy(services);
        DependencyContainerService.RegisterCorsConfigRestriction(services, _configuration);
        DependencyContainerService.RegisterJwtConfig(services, _configuration);
        DependencyContainerService.RegisterHttpClientConfig(services);
        services.AddHttpContextAccessor();
        DependencyContainerService.RegisterSeriLog(services, _configuration);
        DependencyContainerService.RegisterKissLog(services);
        DependencyContainerSwagger.RegisterSwaggerConfig(services);
        DependencyContainerService.RegisterMediator(services);
        services.AddMemoryCache();
        services.AddControllers();
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
        services.AddProblemDetails();
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        DependencyContainerApp.UseAppConfig(app, env, configuration);
        DependencyContainerSwagger.UseSwaggerConfig(app, provider);
    }
}

