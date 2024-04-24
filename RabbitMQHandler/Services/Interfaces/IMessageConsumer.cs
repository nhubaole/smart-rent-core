namespace RabbitMQHandler.Services.Interfaces
{
    public interface IMessageConsumer
    {
        public Task<string> ReceiveMessageAsync(string routingKey);
    }
}
