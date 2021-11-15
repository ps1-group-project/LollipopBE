﻿namespace Lollipop.API.Controllers
{
    using MediatR;
    using Microsoft.AspNetCore.Mvc;
    using System.Collections.Generic;
    using System.Threading.Tasks;
    using Lollipop.Application.Advertisement.Queries;
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
        public async Task<ActionResult<IEnumerable<Advertisement>>> GetAdvertisements() =>
            Ok(await _mediator.Send(new GetAdvertisementsQuery()));

    }
}
