using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RabbitMQ.Client;
using Newtonsoft.Json;

namespace PubSubPatternRabbit.Publisher.Api.RabbitConnection
{
    public sealed class RabbitConfiguration
    {
        private static readonly Lazy<RabbitConfiguration> _configuration =
            new Lazy<RabbitConfiguration>(() => new RabbitConfiguration());

        public static RabbitConfiguration Instance { get { return _configuration.Value; } }

        private readonly IConnectionFactory _connectionFactory;
        private readonly IConnection _rabbitMqConnection;
        
        private RabbitConfiguration()
        {
            this._connectionFactory = new ConnectionFactory()
            {
                HostName = "localhost",
            };

            this._rabbitMqConnection = this._connectionFactory.CreateConnection();                   
        }

        public IConnection GetConnection()
        {
           return this._rabbitMqConnection;
        }
        
        public class Publisher : IRabbitConfiguration
        {
            public void PublishMessageToQueue(Models.SendMessageCommand command)
            {
                var codifiedMessage = JsonConvert.SerializeObject(command);
                var messageBody = Encoding.UTF8.GetBytes(codifiedMessage);


                var rabbitConnection = RabbitConfiguration.Instance.GetConnection();

                    using (var channel = rabbitConnection.CreateModel())
                        channel.BasicPublish(
                            exchange: String.Empty,
                            routingKey: "pubSubPattern",
                            basicProperties: null,
                            body: messageBody);
            }

        }
        
    }
}
