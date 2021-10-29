namespace Lollipop.API.Controllers
{
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Mvc;
    using MediatR;
    using Lollipop.Application.Keyword.Commands;

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
    }
}
