namespace WebAPI.Application.BackgroundMessageServices.ServiceBus;

public interface IServiceBusService<TEntity> : IDisposable where TEntity : class
{
    Task SendMessage(string queueName, TEntity entity);
    Task ReceiveMessage(string queueName, TEntity entity);
    Task ReceiveMessageAsync(string queueName, TEntity entity);
}
