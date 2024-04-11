using WebAPI.Application.Interfaces;
using WebAPI.Application.Services;
using Microsoft.Extensions.DependencyInjection;

namespace WebAPI.Infra.Structure.IoC;

public static class DependencyContainerConsole
{
    public static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddTransient<IEmailService, EmailService>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();
        // Para utilizar a interface, basta fazer a linha abaixo
        // servicesProvider.GetService<IEmailService>();
        return servicesProvider;
    }
}
