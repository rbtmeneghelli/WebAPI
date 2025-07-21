using WebMinimalAPI._2._Application.Interfaces;
using WebMinimalAPI._2._Application.Services;
using WebMinimalAPI_Aot._2._Application.Interfaces;
using WebMinimalAPI_Aot._2._Application.Services;
using WebMinimalAPI_Aot._4._InfraStructure.Repositories;

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
}
