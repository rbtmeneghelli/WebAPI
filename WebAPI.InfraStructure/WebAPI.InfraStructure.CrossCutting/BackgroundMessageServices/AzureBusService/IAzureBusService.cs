using Azure.Messaging.ServiceBus;
using WebAPI.Domain;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.AzureBusService;

public abstract class IAzureBusService<TEntity> : IAsyncDisposable where TEntity : class
{
    protected ServiceBusClient _ServiceBusClient { get; init; }
    protected ServiceBusProcessor _processor { get; set; }

    protected IAzureBusService(EnvironmentVariables environmentVariables)
    {
        _ServiceBusClient = new ServiceBusClient(environmentVariables.ServiceBusSettings.Server);
    }

    public abstract Task SendMessage(string queueName, TEntity entity);
    public abstract Task ReceiveMessage(string queueName, TEntity entity);
    public abstract Task ReceiveMessageAsync(string queueName, TEntity entity);
    public abstract Task SendMessage(string topicName, TEntity entity, CancellationToken cancellationToken = default);

    public async ValueTask DisposeAsync()
    {
        await _processor.DisposeAsync();
    }
}