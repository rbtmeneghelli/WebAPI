using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using System.Text.Json;
using WebAPI.Domain;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ;

public sealed class RabbitMQService<T> : IRabbitMQService<T> where T : class
{
    public RabbitMQService(EnvironmentVariables environmentVariables) : base(environmentVariables)
    {
    }

    /// <summary>
    /// Publisher FanOut to send same message from queues in sameTime. ExchangeName must be the same in SendandReceive
    /// </summary>
    /// <param name="ExchangeName"></param>
    /// <param name="QueueName"></param>
    /// <param name="ObjectValue"></param>
    /// <returns></returns>
    public override async Task SendMessageToQueueInSameTime(string ExchangeName, T ObjectValue)
    {
        using (var connection = _ConnectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Fanout);
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ObjectValue));
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
    public override async Task ReceiveMessageToQueueInSameTime(string ExchangeName)
    {
        var connection = _ConnectionFactory.CreateConnection();
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
            //await _utilService.ProcessingTask(message);
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
    public override async Task SendMessageToQueueRouting(string ExchangeName, string RoutingKey, T ObjectValue)
    {
        using (var connection = _ConnectionFactory.CreateConnection())
        {
            using (var channel = connection.CreateModel())
            {
                channel.ExchangeDeclare(exchange: ExchangeName, type: ExchangeType.Direct);
                channel.QueueDeclare(queue: "Excel",
                            durable: false,
                            exclusive: false,
                            autoDelete: false,
                            arguments: null);
                var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ObjectValue));
                channel.BasicPublish(
                             exchange: ExchangeName,
                             routingKey: "Excel",
                             basicProperties: null,
                             body: body);
                Console.WriteLine($"Enviado mensagem {JsonSerializer.Serialize(ObjectValue)} para o publicador {ExchangeName} com destino a rota {RoutingKey} com sucesso");
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
    public override async Task ReceiveMessageToQueueRouting(string ExchangeName, string RoutingKey)
    {
        var connection = _ConnectionFactory.CreateConnection();
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
            //await _utilService.ProcessingTask(message);
        };

        channel.BasicConsume(queue: queueName,
                             autoAck: true,
                             consumer: consumer);

        await Task.CompletedTask;
    }
}
