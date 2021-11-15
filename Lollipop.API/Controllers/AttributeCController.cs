namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.AttributeC.Queries;
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
        public async Task<ActionResult<IEnumerable<Category>>> GetAttributesC([FromQuery] GetAttributesCQuery query) =>
            Ok(await _mediator.Send(query));

    }
}
