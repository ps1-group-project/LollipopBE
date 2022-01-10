namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.ForbiddenWord.Queries;
    using Lollipop.Core.Models;
    using Lollipop.Application.ForbiddenWord.Commands;

    [ApiController]
    [Route("[controller]/[action]")]
    public class ForbiddenWordController : Controller
    {
        private readonly IMediator _mediator;
        public ForbiddenWordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ForbiddenWord>>> GetAll([FromQuery] GetForbiddenWordsQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult<ForbiddenWord>> GetById([FromQuery] GetForbiddenWordsByIdQuery query) =>
            Ok(await _mediator.Send(query));

       // [HttpDelete]
        // public async Task<int> DeleteById([FromQuery] Dele command) =>
        //     await _mediator.Send(command);

        [HttpPut]
        public async Task<int> Update([FromBody] UpdateForbiddenWordCommand command) =>
            await _mediator.Send(command);

        [HttpPost]
        public async Task<int> Create([FromBody] CreateForbiddenWord command) =>
            await _mediator.Send(command);

    }
}
