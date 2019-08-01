using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;

namespace MessageConsumer
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var rabbitMqConnectionFactory = new ConnectionFactory
            {
                HostName = "localhost"
            };

            // 1. Setup Connection and Channel
            using (var connection = rabbitMqConnectionFactory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    // 2. Create queue to make sure it is created since we will consume from it
                    // If the queue already created by Producer - it won't be created again
                    var queueName = "HelloWorldQueue";
                    channel.QueueDeclare(queueName, false, false, false, null);

                    // 3. Setup Consumer
                    var consumer = new EventingBasicConsumer(channel);

                    // 4. Add handler to Consumer's Received event to receive a message
                    consumer.Received += (model, eventArgs) =>
                    {
                        var byteMessageFromBody = eventArgs.Body;
                        var plainMessageFromBody = Encoding.UTF8.GetString(byteMessageFromBody);
                        Console.WriteLine($" [x] Message received: {plainMessageFromBody}");
                    };

                    // 5. Bind Message Queue with Consumer, so it will listen for messages in that Queue
                    channel.BasicConsume(queueName, true, consumer);

                    Console.WriteLine(" Press any key to exit.");
                    Console.ReadKey();
                }
            }
        }
    }
}
