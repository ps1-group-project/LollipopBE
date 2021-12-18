using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Lollipop.Application.Keyword.Commands;
using Lollipop.Application.Keyword.Queries;
using System.Collections.Generic;
using Lollipop.Core.Models;

namespace Lollipop.API.Controllers
{

    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
    }
}
