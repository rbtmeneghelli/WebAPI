using Confluent.Kafka;
using WebAPI.Domain.ExtensionMethods;

namespace WebAPI.Application.BackgroundMessageServices.Kafka;

public sealed class KafkaService<TEntity> : IKafkaService<TEntity> where TEntity : class
{
    private EnvironmentVariables _EnvironmentVariables { get; }

    public KafkaService(EnvironmentVariables environmentVariables)
    {
        _EnvironmentVariables = environmentVariables;
    }

    private ProducerConfig GetProducerConfig()
    {
        return new ProducerConfig { BootstrapServers = _EnvironmentVariables.KafkaSettings.BootstrapServers };
    }

    private ConsumerConfig GetConsumerConfig(string consumerGroup)
    {
        return new ConsumerConfig
        {
            BootstrapServers = _EnvironmentVariables.KafkaSettings.BootstrapServers,
            GroupId = consumerGroup,
            AutoOffsetReset = AutoOffsetReset.Earliest
        };
    }

    public async Task SendMessageToQueue(string topicName, TEntity entity)
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

            var deliveryReport = await producer.ProduceAsync(topicName, message);

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

    public async Task ReceiveMessageFromQueue(string topicName, string consumerGroup)
    {
        var consumerConfig = GetConsumerConfig(consumerGroup);

        using var consumer = new ConsumerBuilder<Ignore, string>(consumerConfig).Build();

        consumer.Subscribe(topicName);

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
