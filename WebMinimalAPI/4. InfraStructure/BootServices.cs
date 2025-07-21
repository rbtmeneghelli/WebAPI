using Microsoft.OpenApi.Models;
using FluentValidation;
using WebMinimalAPI._2._Application.Services;
using WebMinimalAPI._2._Application.Interfaces;
using WebMinimalAPI._4._InfraStructure.Repositories;
using WebMinimalAPI._2._Application.Validators;

namespace WebMinimalAPI._4._InfraStructure;

public static class BootServices
{
    public static void RegisterServices(this IServiceCollection services)
    {
        services
        .AddScoped<IProductRepository, ProductRepository>()
        .AddScoped<IFileService, FileService>()
        .AddScoped<IProductService, ProductService>();
    }

    public static void RegisterFluentValidationService(this IServiceCollection services)
    {
        services.AddValidatorsFromAssemblyContaining<ProductDTOValidator>();
    }

    public static void RegisterSwaggerService(this IServiceCollection services)
    {
        // Swagger
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen(opt =>
        {
            opt.SwaggerDoc("v1", new OpenApiInfo { Title = "MyApp API", Version = "v1" });
            var xmlPath = Path.Combine(AppContext.BaseDirectory, "MyApp.Api.xml");
            if (File.Exists(xmlPath))
                opt.IncludeXmlComments(xmlPath);
        });
    }
}
