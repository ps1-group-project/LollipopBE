namespace Lollipop.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Lollipop.Application.Keyword.Commands;
    using Lollipop.Application.Keyword.Queries;
    using System.Collections.Generic;
    using Lollipop.Core.Models;

    [ApiController]
    [Route("[controller]/[action]")]
    public class KeywordController : ControllerBase
    {
        private readonly IMediator _mediator;

        public KeywordController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //localhost:port/Keyword/CreateKeyword
        [HttpPost]
        public async Task CreateKeyword([FromBody] CreateKeywordCommand command) =>
            await _mediator.Send(command);

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Keyword>>> GetKeywords() =>
            Ok(await _mediator.Send(new GetKeywordsQuery()));

        [HttpGet]
        public async Task<ActionResult> GetKeywordById([FromQuery] GetKeywordByIdQuery query) =>
            Ok(await _mediator.Send(query));
    }
}
