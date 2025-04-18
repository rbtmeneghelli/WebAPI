namespace WebAPI.Domain.Models;

public record RabbitMQConsumer
{
    public IServiceProvider ServiceProvider { get; set; }
    public string QueueName { get; set; }
    public bool QueueIsDurable { get; set; }

    public RabbitMQConsumer() { }

    public RabbitMQConsumer(
        IServiceProvider serviceProvider,
        string queueName,
        bool queueIsDurable)
    {
        ServiceProvider = serviceProvider;
        QueueName = queueName;
        QueueIsDurable = queueIsDurable;
    }
}
