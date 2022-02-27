namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.Advertisement.Queries;
    using Lollipop.Application.Advertisement.Commands;
    using Lollipop.Core.Models;
    using Lollipop.API.Filters;

    [CORSActionFilter]
    [ExceptionFilter]
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
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAll([FromQuery] GetAdvertisementsQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult<Advertisement>> GetById([FromQuery] GetAdvertisementByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task Create([FromBody] CreateAdvertisementCommand command) =>
             await _mediator.Send(command);

        [HttpDelete]
        public async Task Delete([FromQuery] DeleteAdvertisementCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task Update([FromBody] UpdateAdvertisementCommand command) =>
            await _mediator.Send(command);

        [HttpPost]
        public async Task AddCategory([FromBody] AddAdvertCategoryCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task DeleteCategory([FromBody] DeleteAdvertCategoryCommand command) =>
            await _mediator.Send(command);
            
        [HttpPost]
        public async Task AddKeyword([FromBody] AddAdvertKeywordCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task DeleteKeyword([FromBody] DeleteAdvertKeywordCommand command) =>
            await _mediator.Send(command);
    }
}
