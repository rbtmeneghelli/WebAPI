using WebAPI.Domain;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Infra.Structure.IoC.HostedService;

/// <summary>
/// Na nossa ConfigureServices da classe Startup, adicionar o serviço abaixo.
/// services.AddHostedService<TimerHostedService>();
/// Link de referencia >> https://renicius-pagotto.medium.com/background-services-com-o-hosted-service-asp-net-core-c5c014c0c965
/// </summary>
public class TimerHostedService : IHostedService
{
    private readonly ILogger _logger;

    public TimerHostedService(ILogger<TimerHostedService> logger)
    {
        _logger = logger;
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        new Timer(ExecuteProcess, null, TimeSpan.Zero, TimeSpan.FromSeconds(5));
        return Task.CompletedTask;
    }

    public Task StopAsync(CancellationToken cancellationToken)
    {
        _logger.LogInformation("...Process Stopping...");
        _logger.LogInformation($"{DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()}");
        return Task.CompletedTask;
    }

    private void ExecuteProcess(object state)
    {
        _logger.LogInformation("...Process Executing...");
        _logger.LogInformation($"{DateOnlyExtensionMethods.GetDateTimeNowFromBrazil()}");
    }
}
