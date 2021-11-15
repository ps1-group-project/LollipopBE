namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.ForbiddenWord.Queries;
    using Lollipop.Core.Models;

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
        public async Task<ActionResult<IEnumerable<ForbiddenWord>>> GetForbiddenWords() =>
            Ok(await _mediator.Send(new GetForbiddenWordsQuery()));

    }
}
