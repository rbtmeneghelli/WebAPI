using WebMinimalCarterScalarAPI.Repository;
using WebMinimalCarterScalarAPI.Repository.Interfaces;

namespace WebMinimalCarterScalarAPI.Configuration;

public static class ContainerServicos
{
    public static void RegistrarServicos(this IServiceCollection services)
    {
        services.AddSingleton<IProductRepository, ProductRepository>();
    }
}
