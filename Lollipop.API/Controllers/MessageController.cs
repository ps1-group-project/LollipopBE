namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.Message.Commands;
    using Lollipop.Application.Message.Queries;
    using Lollipop.Core.Models;

    [ApiController]
    [Route("[controller]/[action]")]
    public class MessageController : Controller
    {
        private readonly IMediator _mediator;
        public MessageController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Message>>> GetAll([FromQuery] GetMessagesQuery  query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] GetMessageByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task Create([FromBody] CreateMessageCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task Delete([FromBody] DeleteMessageCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task Update([FromBody] UpdateMessageCommand command) =>
            await _mediator.Send(command);
    }
}
