using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace WebAPI.Infra.Structure.IoC.HostedService.AzureServiceBus.Consumer;

/// <summary>
/// Na nossa ConfigureServices da classe Startup, adicionar o serviço abaixo.
/// services.AddHostedService<ConsumerQueue>();
/// Link de referencia >> https://renicius-pagotto.medium.com/azure-service-bus-implementando-os-consumers-consumidores-parte-3-d817c003af37
/// </summary>
public class ConsumerQueue : IHostedService
{
    static IQueueClient queueClient;
    private readonly IConfiguration _config;

    public ConsumerQueue(IConfiguration config)
    {
        _config = config;
        var serviceBusConnection = _config.GetValue<string>("AzureBusConnectionString");
        queueClient = new QueueClient(serviceBusConnection, "product");
    }

    public Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("############## INICIANDO CONSUMER DA FILA ####################");
        ProcessMessageHandler();
        return Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("############## DESLIGANDO CONSUMER DA FILA ####################");
        await queueClient.CloseAsync();
        await Task.CompletedTask;
    }

    private void ProcessMessageHandler()
    {
        var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        {
            MaxConcurrentCalls = 1,
            AutoComplete = false
        };

        queueClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
    }

    private async Task ProcessMessagesAsync(Message message, CancellationToken token)
    {
        Console.WriteLine("### PROCESSANDO MENSAGEM FILA ###");
        Console.WriteLine($"{DateTime.Now}");
        Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
        await queueClient.CompleteAsync(message.SystemProperties.LockToken);
    }

    private Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
    {
        Console.WriteLine($"Message handler encountered an exception {exceptionReceivedEventArgs.Exception}.");
        var context = exceptionReceivedEventArgs.ExceptionReceivedContext;
        Console.WriteLine("Exception context for troubleshooting:");
        Console.WriteLine($"- Endpoint: {context.Endpoint}");
        Console.WriteLine($"- Entity Path: {context.EntityPath}");
        Console.WriteLine($"- Executing Action: {context.Action}");
        return Task.CompletedTask;
    }
}