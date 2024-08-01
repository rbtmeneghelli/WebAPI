namespace WebAPI.Application.BackgroundMessageServices.Kafka;

public interface IKafkaService<TEntity> : IDisposable where TEntity : class
{
    Task SendMessageToQueue(string topicName, TEntity entity);
    Task ReceiveMessageFromQueue(string topicName, string consumerGroup);
}
