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
        var producerConfig = GetProducerConfig();
        using var producer = new ProducerBuilder<Null, string>(producerConfig).Build();

        try
        {
            // Nesse exemplo abaixo estamos enviando uma mensagem sem chave
            // Para enviar com chave, basta informar o valor na propriedade Key
            var message = new Message<Null, string>
            {
                Value = entity.SerializeObject()
            };

            var deliveryReport = await producer.ProduceAsync(_TopicName, message);

            if (deliveryReport.Status == PersistenceStatus.Persisted)
            {
                Console.WriteLine($"Mensagem entregue com sucesso: {deliveryReport.TopicPartitionOffset}");
            }
            else
            {
                Console.WriteLine($"Falha ao entregar a mensagem");
            }
        }
        catch (ProduceException<Null, string> e)
        {
            Console.WriteLine($"Falha ao produzir a mensagem: {e.Error.Reason}");
        }
    }

    public async Task ReceiveMessageFromQueue()
    {
        var consumerConfig = GetConsumerConfig();

        using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

        consumer.Subscribe(_TopicName);

        try
        {
            while (true)
            {
                var message = consumer.Consume();
                var objectResult = message.Message.Value.DeserializeObject<TEntity>();
                await Task.CompletedTask;
            }
        }
        catch (OperationCanceledException)
        {
            consumer.Close();
        }
    }

    public void Dispose()
    {
        GC.SuppressFinalize(this);
    }
}
