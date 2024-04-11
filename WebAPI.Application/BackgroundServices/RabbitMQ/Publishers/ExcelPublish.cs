using WebAPI.Application.BackgroundServices.RabbitMQ.Generic;
using RabbitMQ.Client;
using System.Text.Json;

namespace WebAPI.Application.BackgroundServices.RabbitMQ.Publishers;

public sealed class QueueExcelFilePublish
{
    private readonly RabbitMQService<Report> _rabbitMQService;

    public QueueExcelFilePublish()
    {
        _rabbitMQService = new RabbitMQService<Report>();
    }

    public async Task RunQueueExcelFilePublish<T>(string QueueName, T ObjectValue, bool QueueIsDurable)
    {
        var factory = _rabbitMQService.ConfigConnectionFactory();
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: QueueName,
                     durable: QueueIsDurable,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        var body = Encoding.UTF8.GetBytes(JsonSerializer.Serialize(ObjectValue));
        var properties = channel.CreateBasicProperties();

        if (QueueIsDurable)
            properties.Persistent = true;

        channel.BasicPublish(exchange: "",
                             routingKey: QueueName,
                             basicProperties: QueueIsDurable ? properties : null,
                             body: body);

        Console.WriteLine($"Enviado mensagem {body} para a fila {QueueName} com sucesso");
        await Task.CompletedTask;
    }
}
