using WebAPI.Domain.ExtensionMethods;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace WebAPI.Application.BackgroundMessageServices.RabbitMQ;

public sealed class RabbitMQService<TEntity> : IRabbitMQService<TEntity> where TEntity : class
{
    public EnvironmentVariables _EnvironmentVariables { get; set; }

    public RabbitMQService(EnvironmentVariables environmentVariables)
    {
        _EnvironmentVariables = environmentVariables;
    }

    public ConnectionFactory ConfigConnectionFactory()
    {
        return new ConnectionFactory()
        {
            HostName = _EnvironmentVariables.RabbitMQSettings.HostName,
            UserName = _EnvironmentVariables.RabbitMQSettings.UserName,
            Password = _EnvironmentVariables.RabbitMQSettings.Password,
            DispatchConsumersAsync = true
        };
    }

    public async Task SendMessageToWorkQueue(string QueueName, TEntity ObjectValue)
    {
        var factory = ConfigConnectionFactory();
        using var connection = factory.CreateConnection();
        using var channel = connection.CreateModel();

        channel.QueueDeclare(queue: QueueName,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        var body = Encoding.UTF8.GetBytes(ObjectValue.SerializeObject());
        var properties = channel.CreateBasicProperties();
        properties.Persistent = true;

        channel.BasicPublish(exchange: string.Empty,
                             routingKey: QueueName,
                             basicProperties: properties,
                             body: body);

        Console.WriteLine($"Enviado mensagem {body} para a fila {QueueName} com sucesso");
        await Task.CompletedTask;
    }

    public async Task ReceiveMessageFromWorkQueue(string QueueName)
    {
        var factory = ConfigConnectionFactory();
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: QueueName,
                     durable: true,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        #region [Make Consumer get one message to process until end]
        channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        #endregion

        var consumer = new AsyncEventingBasicConsumer(channel);

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            int dots = message.Split('.').Length - 1;
            Thread.Sleep(dots * 1000);
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);

            await Task.CompletedTask;
        };

        channel.BasicConsume(queue: QueueName,
                             autoAck: false,
                             consumer: consumer);

        await Task.CompletedTask;
    }


    /// <summary>
    /// Publisher FanOut to send same message from queues in sameTime. ExchangeName must be the same in SendandReceive
    /// </summary>
    /// <param name="ExchangeName"></param>
    /// <param name="QueueName"></param>
    /// <param name="ObjectValue"></param>
    /// <returns></returns>
    public async Task SendMessageToQueueInSameTime(string ExchangeName, TEntity ObjectValue)
    {
        var factory = ConfigConnectionFactory();
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
                var body = Encoding.UTF8.GetBytes(ObjectValue.SerializeObject());
                var properties = channel.CreateBasicProperties();
                channel.BasicPublish(exchange: ExchangeName,
                            routingKey: "",
                            basicProperties: null,
                            body: body);
                Console.WriteLine($"Enviado mensagem {body} para o publicador {ExchangeName} com sucesso");
                await Task.CompletedTask;
            }
        }
    }

    /// <summary>
    /// Publisher FanOut to send same message from queues in sameTime. ExchangeName must be the same in SendandReceive
    /// </summary>
    /// <param name="ExchangeName"></param>
    /// <param name="QueueName"></param>
    /// <param name="ObjectValue"></param>
    /// <returns></returns>
    public async Task ReceiveMessageToQueueInSameTime(string ExchangeName)
    {
        var factory = ConfigConnectionFactory();
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();
        channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);

        #region [Will generate Random Queue]
        var queueName = channel.QueueDeclare().QueueName;
        #endregion

        channel.QueueBind(queue: queueName,
                          exchange: ExchangeName,
                          routingKey: "");

        var consumer = new AsyncEventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            await Task.CompletedTask;
        };

        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);

        await Task.CompletedTask;
    }

    /// <summary>
    /// Publisher Direct to send message from queues with same routing key and exchangeName. 
    /// </summary>
    /// <param name="ExchangeName"></param>
    /// <param name="RoutingKey"></param>
    /// <param name="ObjectValue"></param>
    /// <returns></returns>
    public async Task SendMessageToQueueRouting(string ExchangeName, string RoutingKey, TEntity ObjectValue)
    {
        var factory = ConfigConnectionFactory();
        using (var connection = factory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Direct);
                channel.QueueDeclare(queue: "Excel",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
                var body = Encoding.UTF8.GetBytes(ObjectValue.SerializeObject());
                channel.BasicPublish(
                             exchange: ExchangeName,
                             routingKey: "Excel",
                             basicProperties: null,
                             body: body);
                Console.WriteLine($"Enviado mensagem {ObjectValue.SerializeObject()} para o publicador {ExchangeName} com destino a rota {RoutingKey} com sucesso");
                await Task.CompletedTask;
            }
        }
    }

    /// <summary>
    /// Publisher Direct to send message from queues with same routing key and exchangeName. 
    /// </summary>
    /// <param name="ExchangeName"></param>
    /// <param name="RoutingKey"></param>
    /// <param name="ObjectValue"></param>
    /// <returns></returns>
    public async Task ReceiveMessageToQueueRouting(string ExchangeName, string RoutingKey)
    {
        var factory = ConfigConnectionFactory();
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Direct);
        var queueName = channel.QueueDeclare().QueueName;
        channel.QueueBind(queue: queueName, exchange: ExchangeName, routingKey: RoutingKey);
        var consumer = new EventingBasicConsumer(channel);
        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);
            var routingKey = ea.RoutingKey;
            await Task.CompletedTask;
        };

        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);

        await Task.CompletedTask;
    }
}
