namespace WebAPI.Application.Interfaces.BusMessageService;

public interface IRabbitMQService<T> where T : class
{
    Task SendMessageToWorkQueue(string QueueName, T ObjectValue);

    Task ReceiveMessageFromWorkQueue(string QueueName);

    Task SendMessageToQueueInSameTime(string ExchangeName, T ObjectValue);

    Task ReceiveMessageToQueueInSameTime(string ExchangeName);

    Task SendMessageToQueueRouting(string ExchangeName, string RoutingKey, T ObjectValue);

    Task ReceiveMessageToQueueRouting(string ExchangeName, string RoutingKey);
}
