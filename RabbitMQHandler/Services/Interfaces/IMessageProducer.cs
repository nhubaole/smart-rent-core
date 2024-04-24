﻿namespace RabbitMQHandler.Services.Interfaces
{
    public interface IMessageProducer
    {
        public void SendingMessage<T>(T message, string routingKey);
    }
}
