using Microsoft.Extensions.DependencyInjection;
using WebAPI.Application.Services.Configuration;
using WebAPI.Domain.Interfaces.Services.Configuration;

namespace WebAPI.InfraStructure.IoC.Containers;

public static class ContainerConsole
{
    public static ServiceProvider ConfigureServices()
    {
        ServiceCollection services = new ServiceCollection();
        services.AddTransient<IEmailService, EmailService>();
        ServiceProvider servicesProvider = services.BuildServiceProvider();
        // Para utilizar a interface, basta fazer a linha abaixo
        //servicesProvider.GetService<IEmailService>();
        return servicesProvider;
    }
}
