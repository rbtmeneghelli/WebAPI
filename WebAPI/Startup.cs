using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebAPI.Infra.Data.Context;
using WebAPI.IoC;
using WebAPI.IoC.Middleware.ExceptionHandler;

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
        DependencyContainerService.RegisterHealthCheck(services, _configuration);
        DependencyContainerService.RegisterHealthCheckDashboard(services);
    }

    public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IApiVersionDescriptionProvider provider, IConfiguration configuration)
    {
        DependencyContainerApp.UseAppConfig(app, env, configuration);
        DependencyContainerSwagger.UseSwaggerConfig(app, provider);
    }
}

