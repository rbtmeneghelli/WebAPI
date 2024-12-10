using Azure.Messaging.ServiceBus;
using System.Text.Json;
using WebAPI.Domain;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.ServiceBus;

public sealed class ServiceBusService<TEntity> : IServiceBusService<TEntity> where TEntity : class
{
    private EnvironmentVariables _EnvironmentVariables { get; }

    public ServiceBusService(EnvironmentVariables environmentVariables)
    {
        _EnvironmentVariables = environmentVariables;
    }

    public async Task SendMessage(string queueName, TEntity entity)
    {
        await using (var client = new ServiceBusClient(_EnvironmentVariables.ServiceBusSettings.Server))
        {
            ServiceBusSender sender = client.CreateSender(queueName);
            ServiceBusMessage message = new ServiceBusMessage(JsonSerializer.Serialize(entity));
            await sender.SendMessageAsync(message);
        }
    }

    public async Task ReceiveMessage(string queueName, TEntity entity)
    {
        await using (var client = new ServiceBusClient(_EnvironmentVariables.ServiceBusSettings.Server))
        {
            ServiceBusReceiver receiver = client.CreateReceiver(queueName);
            ServiceBusReceivedMessage receivedMessage = await receiver.ReceiveMessageAsync();
            if (receivedMessage != null)
            {
                Console.WriteLine($"Mensagem recebida: {receivedMessage.Body}");
                // Chama algum metodo para processar a mensagem, no final finaliza a mensagem!
                await receiver.CompleteMessageAsync(receivedMessage);
            }
        }
    }

    public async Task ReceiveMessageAsync(string queueName, TEntity entity)
    {
        await using (var client = new ServiceBusClient(_EnvironmentVariables.ServiceBusSettings.Server))
        {
            var processor = client.CreateProcessor(queueName, new ServiceBusProcessorOptions());

            processor.ProcessMessageAsync += async args =>
            {
                try
                {
                    var body = args.Message.Body.ToString();
                    Console.WriteLine($"Received: {body}");
                    await args.CompleteMessageAsync(args.Message);
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"An error occurred while processing the message. {ex}");
                }
            };

            processor.ProcessErrorAsync += async args =>
            {
                Console.WriteLine($"An error occurred while processing messages. {args.Exception}");
            };

            await processor.StartProcessingAsync();
            Console.WriteLine("Press any key to stop receiving messages...");
            Console.ReadKey();
            await processor.StopProcessingAsync();
        }

    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

