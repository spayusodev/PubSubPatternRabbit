using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PubSubPatternRabbit.Publisher.Api.Models
{
    public class SendMessageCommand
    {
        public Guid Id { get; set; }
        public DateTime DateTimeSent { get; set; }
        public string MessageData { get; set; }

        public SendMessageCommand(string MessageData)
        {
            this.Id = Guid.NewGuid();
            this.DateTimeSent = DateTime.Now;
            this.MessageData = MessageData;
        }
    }
}
