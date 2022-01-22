namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.AttributeC.Queries;
    using Lollipop.Application.AttributeC.Commands;
    using Lollipop.Core.Models;

    [ApiController]
    [Route("[controller]/[action]")]
    public class AttributeCController : Controller
    {
        private readonly IMediator _mediator;
        public AttributeCController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll([FromQuery] GetAttributesCQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] GetAttributeByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task Create([FromBody] CreateAttributeCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task Delete([FromBody] DeleteAttributeCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task Update([FromBody] UpdateAttributeCommand command) =>
            await _mediator.Send(command);
    }
}
