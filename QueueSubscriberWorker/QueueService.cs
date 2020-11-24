using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using System;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace QueueServiceWorker
***REMOVED***
    public class QueueService : BackgroundService
    ***REMOVED***
        private IConnection _connection;
        private IModel _channel;
        private string _consumerTag;

        private readonly ILogger<QueueService> _logger;
        public QueueService(ILogger<QueueService> logger)
        ***REMOVED***
            _logger = logger;
       ***REMOVED***

        protected override Task ExecuteAsync(CancellationToken stoppingToken)
        ***REMOVED***
            var hostName = "localhost";
            var portNumber = "5672";

            var connectionFactory = new ConnectionFactory()
            ***REMOVED***
                Uri = new Uri($"amqp://guest:guest@***REMOVED***hostName***REMOVED***:***REMOVED***portNumber***REMOVED***"),
           ***REMOVED***;

            _connection = connectionFactory.CreateConnection();
            _channel = _connection.CreateModel();
            _channel.BasicQos(prefetchSize: 0, prefetchCount: 1, global: false);
            _logger.LogInformation("Waiting for Messages...");

            var consumer = new EventingBasicConsumer(_channel);
            consumer.Received += (model, ea) =>
            ***REMOVED***
                var appId = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["app_id"]);
                var messageId = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["message_id"]);
                var contentType = Encoding.UTF8.GetString((byte[])ea.BasicProperties.Headers["content_type"]);
                _logger.LogInformation($"App Id: ***REMOVED***appId***REMOVED***\tMessage Id: ***REMOVED***messageId***REMOVED***\tContent Type: ***REMOVED***contentType***REMOVED***");

                var body = ea.Body;
                var message = Encoding.UTF8.GetString(body.ToArray());
                _logger.LogInformation($"[x] ***REMOVED***message***REMOVED***");
                _channel.BasicAck(ea.DeliveryTag, multiple: false);
           ***REMOVED***;

            var queueName = "videoreceived.queue";
            _consumerTag = _channel.BasicConsume(queue: queueName, autoAck: false, consumer: consumer);
            _logger.LogInformation(" Press [enter] to exit.");
            return Task.CompletedTask;
       ***REMOVED***

        public override Task StopAsync(CancellationToken cancellationToken)
        ***REMOVED***
            _channel.BasicCancel(_consumerTag);
            _channel.Close();
            _connection.Close();
            return base.StopAsync(cancellationToken);
       ***REMOVED***
   ***REMOVED***
***REMOVED***
