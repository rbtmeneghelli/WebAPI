using Azure.Messaging.ServiceBus;
using Newtonsoft.Json;

namespace WebAPI.Application.BackgroundMessageServices.ServiceBus;

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
            ServiceBusMessage message = new ServiceBusMessage(JsonConvert.SerializeObject(entity));
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

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}

