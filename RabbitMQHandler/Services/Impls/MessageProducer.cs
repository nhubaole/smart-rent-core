using RabbitMQ.Client;
using RabbitMQHandler.Services.Interfaces;
using System.Text;
using System.Text.Json;

namespace RabbitMQHandler.Services.Impls
{
    public class MessageProducer : IMessageProducer
    {
        public void SendingMessage<T>(T message, string routingKey)
        {
            var factory = new ConnectionFactory()
            {
                HostName = "host.docker.internal",
                Port = 5672,
                UserName = "rabbitmq",
                Password = "rabbitmq",
                VirtualHost = "/"
            };
            //string routingKey = "channel";
            using var conn = factory.CreateConnection();
            using var chanel = conn.CreateModel();
            chanel.QueueDeclare(routingKey, durable: true, exclusive: false,
                     autoDelete: false,
                     arguments: null);
            string jsonString = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(jsonString);
            chanel.BasicPublish("", routingKey, body: body);
        }
    }
}
