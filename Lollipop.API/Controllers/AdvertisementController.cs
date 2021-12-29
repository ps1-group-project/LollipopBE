namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.Advertisement.Queries;
    using Lollipop.Application.Advertisement.Commands;
    using Lollipop.Core.Models;

    [ApiController]
    [Route("[controller]/[action]")]
    public class AdvertisementController : Controller
    {
        private readonly IMediator _mediator;
        public AdvertisementController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAdvertisements([FromQuery] GetAdvertisementsQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task CreateAdvertisement([FromBody] CreateAdvertisementCommand command) =>
             await _mediator.Send(command);
    }
}
