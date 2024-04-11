using Microsoft.Azure.ServiceBus;
using Microsoft.Extensions.Configuration;
using System.Text;
using System.Text.Json;

namespace WebAPI.Infra.Structure.IoC.HostedService.AzureServiceBus.Publisher;

public class PublisherService
{
    private readonly IConfiguration _config;
    private readonly string serviceBusConnectionString;

    public PublisherService(IConfiguration config)
    {
        _config = config;
        serviceBusConnectionString = _config.GetValue<string>("AzureBusConnectionString");
    }

    public async Task SendMessageToQueue(object data)
    {
        var queueName = "product";
        var client = new QueueClient(serviceBusConnectionString, queueName, ReceiveMode.PeekLock);
        var message = new Message(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)));

        await client.SendAsync(message);
        await client.CloseAsync();
    }

    public async Task SendMessageToTopic(object data)
    {
        var topicName = "product-topic";
        var client = new TopicClient(serviceBusConnectionString, topicName);
        var message = new Message(Encoding.UTF8.GetBytes(JsonSerializer.Serialize(data)));

        await client.SendAsync(message);
        await client.CloseAsync();
    }
}


