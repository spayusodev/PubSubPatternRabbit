using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using RabbitMQ.Client;

namespace PubSubPatternRabbit.Publisher.Api.RabbitConnection
{
    public interface IRabbitConfiguration
    {
        void PublishMessageToQueue(Models.SendMessageCommand command);
    }
}
