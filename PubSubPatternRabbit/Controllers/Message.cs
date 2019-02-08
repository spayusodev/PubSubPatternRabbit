using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace PubSubPatternRabbit.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MessageController : ControllerBase
    {
        private readonly Publisher.Api.IMessageService _publisherService;

        public MessageController(Publisher.Api.IMessageService publisherService)
        {
            this._publisherService = publisherService;
        }
        // POST api/values
        [HttpPost]
        public void Post(string value)
        {
            this._publisherService.PublishMessage(new Publisher.Api.Models.SendMessageCommand(value));
        }

    }
}
