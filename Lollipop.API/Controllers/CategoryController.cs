﻿namespace Lollipop.API.Controllers
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
        /*
        [HttpPost]
        public async Task CreateCategory([FromBody] CreateCategoryCommand command) =>
            await _mediator.Send(command);
        */
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Category>>> GetCategories([FromQuery] GetCategoriesQuery query) =>
            Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<ActionResult> GetCategoryById([FromQuery] GetCategoryByIdQuery query) =>
            Ok(await _mediator.Send(query));
    }
}
