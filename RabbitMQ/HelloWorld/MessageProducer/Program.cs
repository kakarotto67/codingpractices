using System;
using System.Text;
using RabbitMQ.Client;

namespace MessageProducer
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
                    // 2. Create Queue
                    var queueName = "HelloWorldQueue";
                    channel.QueueDeclare(queueName, false, false, false, null);

                    // 3. Create and encode message
                    var plainMessage = "Hello World!";
                    var byteMessage = Encoding.UTF8.GetBytes(plainMessage);

                    // 4. Publish the message event to queue created on step 2
                    channel.BasicPublish(String.Empty, queueName, null, byteMessage);
                    Console.WriteLine($" [x] Message sent: {plainMessage}");

                    Console.WriteLine(" Press any key to exit.");
                    Console.ReadKey();
                }
            }


        }
    }
}
