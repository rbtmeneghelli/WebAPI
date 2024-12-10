using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System.Text;
using WebAPI.Domain.ExtensionMethods;
using WebAPI.Domain.Models;

namespace WebAPI.Infrastructure.CrossCutting.BackgroundMessageServices.RabbitMQ.Consumers;

public sealed class ExcelBackGroundService : BackgroundService
{
    private readonly IRabbitMQService<Report> _rabbitMQService;
    private readonly IServiceProvider _serviceProvider;
    private const string QUEUE_NAME = "QueueExcelFile";
    private const bool QUEUE_IS_DURABLE = false;

    public ExcelBackGroundService(IServiceProvider serviceProvider, IRabbitMQService<Report> rabbitMQService)
    {
        _serviceProvider = serviceProvider;
        _rabbitMQService = rabbitMQService;
    }

    protected override Task ExecuteAsync(CancellationToken stoppingToken)
    {
        QueueExcelFileConsumer queueExcelFileConsumer = new QueueExcelFileConsumer(_rabbitMQService);
        var rabbitMQConsumer = new RabbitMQConsumer(_serviceProvider, QUEUE_NAME, QUEUE_IS_DURABLE);
        queueExcelFileConsumer.RunQueueExcelFileConsumer(rabbitMQConsumer).GetAwaiter().GetResult();
        return Task.CompletedTask;
    }
}

public sealed class QueueExcelFileConsumer
{
    private readonly IRabbitMQService<Report> _rabbitMQService;

    public QueueExcelFileConsumer(IRabbitMQService<Report> rabbitMQService)
    {
        _rabbitMQService = rabbitMQService;
    }

    /// <summary>
    /// When param QueueIsDurable is True, the message send to queue will be consumed one or more consume. 
    /// </summary>
    /// <param name="queueName"></param>
    /// <param name="objectValue"></param>
    /// <param name="QueueIsDurable"></param>
    /// <returns></returns>
    /// 
    public async Task RunQueueExcelFileConsumer(RabbitMQConsumer rabbitMQConsumer)
    {
        var factory = _rabbitMQService.ConfigConnectionFactory();
        var connection = factory.CreateConnection();
        var channel = connection.CreateModel();

        channel.QueueDeclare(queue: rabbitMQConsumer.QueueName,
                     durable: rabbitMQConsumer.QueueIsDurable,
                     exclusive: false,
                     autoDelete: false,
                     arguments: null);

        #region [Make Consumer get one message to process until end]
        channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
        #endregion

        var consumer = new AsyncEventingBasicConsumer(channel);
        string messages = StringExtensionMethod.GetEmptyString();

        consumer.Received += async (model, ea) =>
        {
            var body = ea.Body.ToArray();
            var message = Encoding.UTF8.GetString(body);

            if (rabbitMQConsumer.QueueIsDurable)
            {
                int dots = message.Split('.').Length - 1;
                Thread.Sleep(dots * 1000);
            }

            //using (var scope = rabbitMQConsumer.ServiceProvider.CreateScope())
            //{
            //    var utilService = scope.ServiceProvider.GetService<IUtilService>();
            //    await utilService.ProcessingTask(message);
            //}

            // Em caso de sucesso, faz a assinatura manual de confirmação 
            channel.BasicAck(deliveryTag: ea.DeliveryTag, multiple: false);
        };

        // Em caso de sucesso, faz a assinatura automatica de confirmação, caso o autoAck seja true
        channel.BasicConsume(queue: rabbitMQConsumer.QueueName,
                             autoAck: false,
                             consumer: consumer);

        await Task.CompletedTask;
        return;
    }
}
