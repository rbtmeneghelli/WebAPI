using Confluent.Kafka;
using WebAPI.Domain;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.Kafka;

public abstract class IKafkaService<TEntity> where TEntity : class
{
    protected ProducerConfig _ProducerConfig { get; init; }

    protected IKafkaService(EnvironmentVariables environmentVariables)
    {
        _ProducerConfig = new ProducerConfig { BootstrapServers = environmentVariables.KafkaSettings.BootstrapServers };
    }

    protected virtual ConsumerConfig GetSetConsumer(string consumerGroup)
    {
        return new ConsumerConfig
        {
            BootstrapServers = _ProducerConfig.BootstrapServers,
            GroupId = consumerGroup,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }

    public abstract Task SendMessageToQueue(string topicName, TEntity entity);
    public abstract Task ReceiveMessageFromQueue(string topicName, string consumerGroup);
}