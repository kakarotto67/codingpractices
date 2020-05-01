using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using RabbitMQ.Client.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;
using RabbitMQ.Client.Framing;

namespace CarrotSender.MessageBus.RabbitMq
{
    public class RabbitMqBus : IDisposable
    {
        private readonly IConnection connection;
        private readonly IModel channel;
        private readonly IConfiguration configuration;

        private bool disposed = false;

        private const long Expiration = 259200000;

        public bool ConnectionEstablished { get; }

        public RabbitMqBus(IConnectionFactory connectionFactory, IConfiguration configuration)
        {
            this.configuration = configuration;

            try
            {
                connection = connectionFactory.CreateConnection();
                channel = connection.CreateModel();
                ConnectionEstablished = true;
            }
            catch (BrokerUnreachableException)
            {
                ConnectionEstablished = false;
                return;
            }
        }

        public void PublishMessageToQueue<T>(string queue, T eventMessage)
        {
            if (String.IsNullOrEmpty(queue))
            {
                return;
            }

            // Create queue if not created created yet
            DeclareQueue(queue);

            // Encode event message
            var eventJson = JsonConvert.SerializeObject(eventMessage);
            var eventBytes = Encoding.UTF8.GetBytes(eventJson);

            // Publish the message
            channel.BasicPublish(String.Empty, queue, null, eventBytes);
        }

        public void PublishMessageToExchange(string exchange, string eventJsonMessage)
        {
            if (String.IsNullOrEmpty(exchange) || String.IsNullOrEmpty(eventJsonMessage))
            {
                return;
            }

            // Encode event message
            var eventBytes = Encoding.UTF8.GetBytes(eventJsonMessage);

            // Publish the message
            PublishToExchange(exchange, eventBytes);
        }

        public void ConsumeMessage<T>(string queue, Action<T> handleMessage)
        {
            if (String.IsNullOrEmpty(queue))
            {
                return;
            }

            // Create queue if not created created yet
            DeclareQueue(queue);

            // Setup Consumer
            var consumer = new EventingBasicConsumer(channel);

            // Add handler to Consumer's Received event to receive a message
            consumer.Received += (model, eventArgs) =>
            {
                var eventBytesFromMessageBus = eventArgs.Body;
                var eventJsonFromMessageBus = Encoding.UTF8.GetString(eventBytesFromMessageBus);
                var eventMessageFromMessageBus = JsonConvert.DeserializeObject<T>(eventJsonFromMessageBus);

                handleMessage(eventMessageFromMessageBus);
            };

            // Publish the message
            channel.BasicConsume(queue, true, consumer);
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed)
            {
                return;
            }

            if (disposing)
            {
            }

            channel?.Dispose();
            connection?.Dispose();

            disposed = true;
        }

        #region Private Methods

        private void PublishToExchange(string exchange, byte[] body)
        {
            if (String.IsNullOrEmpty(exchange))
            {
                return;
            }

            DeclareFanoutExchange(exchange);

            var basicProperties = new BasicProperties
            {
                ContentType = "application/json",
                Persistent = true,
                Expiration = Expiration.ToString()
            };

            channel.BasicPublish(exchange, String.Empty, false, (IBasicProperties)basicProperties, body);
        }

        private void DeclareFanoutExchange(string exchange)
        {
            channel.ExchangeDeclare(exchange, "fanout", false, false, null);
        }

        private void DeclareQueue(string queue)
        {
            if (String.IsNullOrEmpty(queue))
            {
                return;
            }

            var isDurable = configuration.GetValue<Boolean>("MessageBusSettings:QueueSettings:UseDurableQueues");

            // Create queue if not created created yet
            channel.QueueDeclare(queue, isDurable, false, false, null);
        }

        #endregion

        ~RabbitMqBus()
        {
            Dispose(false);
        }
    }
}