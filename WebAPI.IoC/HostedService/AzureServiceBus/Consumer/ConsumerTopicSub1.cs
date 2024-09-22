using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using System.Text;

namespace WebAPI.IoC.HostedService.AzureServiceBus.Consumer;

/// <summary>
/// Na nossa ConfigureServices da classe Startup, adicionar o serviço abaixo.
/// services.AddHostedService<ConsumerTopicSub1>();
/// Link de referencia >> https://renicius-pagotto.medium.com/azure-service-bus-implementando-os-consumers-consumidores-parte-3-d817c003af37
/// </summary>
public class ConsumerTopicSub1 : IHostedService
{
    static SubscriptionClient subscriptionClient;
    private readonly IConfiguration _config;

    public ConsumerTopicSub1(IConfiguration config)
    {
        _config = config;
        var serviceBusConnection = _config.GetValue<string>("AzureBusConnectionString");
        subscriptionClient = new SubscriptionClient(serviceBusConnection, "product-topic", "product-sub1");
    }

    public async Task StartAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("############## INICIANDO CONSUMER SUBSCRIPTION 2 ####################");
        ProcessMessageHandler();
        await Task.CompletedTask;
    }

    public async Task StopAsync(CancellationToken cancellationToken)
    {
        Console.WriteLine("############## DESLIGANDO CONSUMER DO TOPICO ####################");
        await subscriptionClient.CloseAsync();
        await Task.CompletedTask;
    }

    public void ProcessMessageHandler()
    {
        var messageHandlerOptions = new MessageHandlerOptions(ExceptionReceivedHandler)
        {
            MaxConcurrentCalls = 1,
            AutoComplete = false
        };

        subscriptionClient.RegisterMessageHandler(ProcessMessagesAsync, messageHandlerOptions);
    }

    public async Task ProcessMessagesAsync(Message message, CancellationToken token)
    {
        Console.WriteLine("### PROCESSANDO MENSAGEM SUBSCRIPTION 1 ###");
        Console.WriteLine($"{DateTime.Now}");
        Console.WriteLine($"Received message: SequenceNumber:{message.SystemProperties.SequenceNumber} Body:{Encoding.UTF8.GetString(message.Body)}");
        await subscriptionClient.CompleteAsync(message.SystemProperties.LockToken);
    }

    public Task ExceptionReceivedHandler(ExceptionReceivedEventArgs exceptionReceivedEventArgs)
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
