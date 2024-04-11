using Confluent.Kafka;
using WebAPI.Application.Interfaces.BusMessageService;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.Services.BusMessageService;


public sealed class KafkaService<TEntity> : IKafkaService<TEntity> where TEntity : class
{
    private readonly string _BootstrapServers;
    private readonly string _TopicName;
    private readonly string _ConsumerGroup;

    public KafkaService()
    {
        _BootstrapServers = "localhost:9092"; //Endereço do broker Kafka
        _TopicName = "nome_do_topico"; //Nome do tópico Kafka
        _ConsumerGroup = "nome_do_grupo"; // Nome do grupo de consumidores
    }

    private ProducerConfig GetProducerConfig()
    {
        return new ProducerConfig { BootstrapServers = _BootstrapServers };
    }

    private ConsumerConfig GetConsumerConfig()
    {
        return new ConsumerConfig { BootstrapServers = _BootstrapServers, GroupId = _ConsumerGroup, AutoOffsetReset = AutoOffsetReset.Earliest };
    }

    public async Task SendMessageToQueue(TEntity entity)
    {
        using var producer = new ProducerBuilder<Null, string>(GetProducerConfig()).Build();

        var message = new Message<Null, string>
        {
            Value = entity.SerializeObject()
        };

        await producer.ProduceAsync(_TopicName, message);
    }

    public async Task ReceiveMessageFromQueue()
    {
        using var consumer = new ConsumerBuilder<Ignore, string>(GetConsumerConfig()).Build();

        consumer.Subscribe(_TopicName);

        while (true)
        {
            var message = consumer.Consume();
            var objectResult = message.Message.Value.DeserializeObject<TEntity>();
            await Task.CompletedTask;
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
