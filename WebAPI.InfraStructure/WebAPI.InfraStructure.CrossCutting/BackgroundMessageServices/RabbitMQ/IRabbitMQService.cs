using RabbitMQ.Client;
using WebAPI.Domain;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ;

public abstract class IRabbitMQService<T> where T : class
{
    public ConnectionFactory _ConnectionFactory { get; init; }

    protected IRabbitMQService(EnvironmentVariables environmentVariables)
    {
        _ConnectionFactory = new ConnectionFactory 
        {
            HostName = environmentVariables.RabbitMQSettings.HostName,
            UserName = environmentVariables.RabbitMQSettings.UserName,
            Password = environmentVariables.RabbitMQSettings.Password,
            DispatchConsumersAsync = true
        };
    }

    public abstract Task SendMessageToQueueInSameTime(string ExchangeName, T ObjectValue);

    public abstract Task ReceiveMessageToQueueInSameTime(string ExchangeName);

    public abstract Task SendMessageToQueueRouting(string ExchangeName, string RoutingKey, T ObjectValue);

    public abstract Task ReceiveMessageToQueueRouting(string ExchangeName, string RoutingKey);
}
