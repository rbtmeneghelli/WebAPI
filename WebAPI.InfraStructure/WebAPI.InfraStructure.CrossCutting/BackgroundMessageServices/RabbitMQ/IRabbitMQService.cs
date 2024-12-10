using RabbitMQ.Client;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ;

public interface IRabbitMQService<TEntity> where TEntity : class
{
    ConnectionFactory ConfigConnectionFactory();

    Task SendMessageToWorkQueue(string QueueName, TEntity ObjectValue);

    Task ReceiveMessageFromWorkQueue(string QueueName);

    Task SendMessageToQueueInSameTime(string ExchangeName, TEntity ObjectValue);

    Task ReceiveMessageToQueueInSameTime(string ExchangeName);

    Task SendMessageToQueueRouting(string ExchangeName, string RoutingKey, TEntity ObjectValue);

    Task ReceiveMessageToQueueRouting(string ExchangeName, string RoutingKey);
}
