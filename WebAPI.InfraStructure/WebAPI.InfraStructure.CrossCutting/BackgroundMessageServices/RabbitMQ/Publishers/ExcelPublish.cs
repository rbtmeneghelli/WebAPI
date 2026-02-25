using RabbitMQ.Client;
using System.Text;
using System.Text.Json;
using WebAPI.Domain.Models;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ.Publishers;

public sealed class QueueExcelFilePublish
{
    private readonly IRabbitMQService<Report> _rabbitMQService;

    public QueueExcelFilePublish(IRabbitMQService<Report> rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    public async Task RunQueueExcelFilePublish<T>(string QueueName, T ObjectValue, bool QueueIsDurable)
    {
        var connection = _rabbitMQService._ConnectionFactory.CreateConnection();
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
