using System;
using System.Text;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;



namespace Subscriber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("SUBSCRIBER TO RABBITMQ");
            

            var factory = new ConnectionFactory()
            {
                HostName = "localhost",
                UserName = "guest",
                Password = "guest"
            };

            
            using (var connection = factory.CreateConnection())
            {
                using (var channel = connection.CreateModel())
                {
                    channel.QueueDeclare(
                        queue: "pubSubPattern",
                        durable: false,
                        exclusive: false,
                        autoDelete: false,
                        arguments: null);


                    while (true)
                    {
                        var consumer = new EventingBasicConsumer(channel);

                        
                        consumer.Received += (model, ea) =>
                        {
                            var message = Encoding.UTF8.GetString(ea.Body);
                            Console.WriteLine("[x] message has been received {0}", message);
                            Console.WriteLine();
                        };

                        channel.BasicConsume(
                            queue: "pubSubPattern",
                            autoAck: true,
                            consumer: consumer);


                    }

                }
            }
        }
    }
}
