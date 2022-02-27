namespace Lollipop.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Lollipop.Application.Keyword.Commands;
    using Lollipop.Application.Keyword.Queries;
    using System.Collections.Generic;
    using Lollipop.Core.Models;
    using Lollipop.API.Filters;

    [ExceptionFilter]
    [CORSActionFilter]
    [ApiController]
    [Route("[controller]/[action]")]
    public class KeywordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeywordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task Create([FromBody] CreateKeywordCommand command) =>
            await _mediator.Send(command);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keyword>>> GetAll([FromQuery] GetKeywordsQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] GetKeywordByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpDelete]
        public async Task Delete([FromBody] DeleteKeywordCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task Update([FromBody] UpdateKeywordCommand command) =>
            await _mediator.Send(command);
    }
}
