namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.Category.Commands;
    using Lollipop.Application.Category.Queries;
    using Lollipop.Core.Models;
    using Microsoft.AspNetCore.Cors;

    [ApiController]
    [Route("[controller]/[action]")]
    public class CategoryController : Controller
    {
        private readonly IMediator _mediator;
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetAll([FromQuery] GetCategoriesQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult> GetById([FromQuery] GetCategoryByIdQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpPost]
        public async Task Create([FromBody] CreateCategoryCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task Delete([FromBody] DeleteCategoryCommand command) =>
            await _mediator.Send(command);

        [HttpPut]
        public async Task Update([FromBody] UpdateCategoryCommand command) =>
            await _mediator.Send(command);

        [HttpPost]
        public async Task AddAttribute([FromBody] AddCatAttributeCommand command) =>
            await _mediator.Send(command);

        [HttpDelete]
        public async Task DeleteAttribute([FromBody] DeleteCatAttributeCommand command) =>
            await _mediator.Send(command);
    }
}
