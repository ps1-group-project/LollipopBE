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
        public async Task<ActionResult<IEnumerable<ForbiddenWord>>> GetForbiddenWords([FromQuery] GetForbiddenWordsQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult<ForbiddenWord>> GetForbiddenWordById([FromQuery] GetForbiddenWordsByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpDelete]
        public async Task<int> DeleteForbiddenWordById([FromBody] DeleteForbiddenWordByIdCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task<int> UpdateForbiddenWord([FromBody] UpdateForbiddenWordCommand command) =>
            await _mediator.Send(command);

        [HttpPost]
        public async Task<int> CreateForbiddenWord([FromBody] CreateForbiddenWord command) =>
            await _mediator.Send(command);

    }
}
