using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubPatternRabbit.Publisher.Api
{
    public class MessageService : IMessageService
    {
        private readonly RabbitConnection.IRabbitConfiguration _publisher;

        public MessageService(RabbitConnection.IRabbitConfiguration rabbitPublisher)
        {
            this._publisher = rabbitPublisher;
        }
        public void PublishMessage(Models.SendMessageCommand command)
        {
            if(command == null)
            {
                throw new ArgumentNullException();
            }

            this._publisher.PublishMessageToQueue(command);

        }
    }
}
