using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQHandler.Services.Interfaces;
using System.Text;

namespace RabbitMQHandler.Services.Impls
{
    public class MessageConsumer : IMessageConsumer
    {
        public async Task<string> ReceiveMessageAsync(string routingKey)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "host.docker.internal",
                Port = 5672,
                UserName = "rabbitmq",
                Password = "rabbitmq",
                VirtualHost = "/"
            };

            var conn = factory.CreateConnection();

            using var chanel = conn.CreateModel();
            chanel.QueueDeclare(routingKey, durable: true, exclusive: false, autoDelete: false, arguments: null);

            var message = "";

            var tcs = new TaskCompletionSource<string>();

            var consumer = new EventingBasicConsumer(chanel);
            consumer.Received += (model, eventArgs) =>
            {
                var body = eventArgs.Body.ToArray();
                message = Encoding.UTF8.GetString(body);
                tcs.SetResult(message);
            };

            chanel.BasicConsume(routingKey, true, consumer);

            return await tcs.Task;
        }

    }
}
