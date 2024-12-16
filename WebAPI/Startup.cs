using Microsoft.AspNetCore.Mvc.ApiExplorer;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore;
using WebAPI.InfraStructure.IoC.Containers;
using WebAPI.InfraStructure.Data.Context;
using WebAPI.Infrastructure.CrossCutting.Middleware.ExceptionHandler;

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

        ContainerService.RegisterDbConnection(services, _configuration);
        ContainerService.RegisterServices(services);
        ContainerService.RegisterMapperConfig(services);
        ContainerService.RegisterConfigs(services, _configuration);
        ContainerService.RegisterPolicy(services);
        ContainerService.RegisterCorsConfigRestriction(services, _configuration);
        ContainerService.RegisterJwtConfig(services, _configuration);
        ContainerService.RegisterHttpClientConfig(services);
        services.AddHttpContextAccessor();
        ContainerService.RegisterSeriLog(services, _configuration);
        ContainerService.RegisterKissLog(services);
        ContainerSwagger.RegisterSwaggerConfig(services);
        ContainerService.RegisterMediator(services);
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

