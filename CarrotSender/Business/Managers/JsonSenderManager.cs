using CarrotSender.Business.Abstracts;
using CarrotSender.MessageBus.RabbitMq;
using System;

namespace CarrotSender.Business.Managers
{
    public class JsonSenderManager : ISenderManager
    {
        private readonly RabbitMqBus _messageBus;

        public bool IsBusReady { get; }

        public JsonSenderManager(RabbitMqBus messageBus)
        {
            _messageBus = messageBus;
            IsBusReady = _messageBus.ConnectionEstablished;
        }

        public void SendMessageToExchange(string exchange, string message)
        {
            _messageBus.PublishMessageToExchange(exchange, message);
        }

        public void SendMessageToQueue(string queue, string message)
        {
            _messageBus.PublishMessageToQueue(queue, message);
        }
    }
}