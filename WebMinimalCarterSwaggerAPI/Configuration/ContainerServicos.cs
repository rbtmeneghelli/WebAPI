using WebMinimalCarterSwaggerAPI.Repository;
using WebMinimalCarterSwaggerAPI.Repository.Interfaces;

namespace WebMinimalCarterSwaggerAPI.Configuration;

public static class ContainerServicos
{
    public static void RegistrarServicos(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}
