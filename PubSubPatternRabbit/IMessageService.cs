using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubPatternRabbit.Publisher.Api
{
    public interface IMessageService
    {
        void PublishMessage(Models.SendMessageCommand command);
    }
}
