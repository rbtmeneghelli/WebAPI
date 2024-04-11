namespace WebAPI.Application.Interfaces.BusMessageService;

public interface IKafkaService<TEntity> : IDisposable where TEntity : class
{
    Task SendMessageToQueue(TEntity entity);
    Task ReceiveMessageFromQueue();
}
