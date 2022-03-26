using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Lollipop.Application.User.Commands;
using Lollipop.Application.User.Queries;
using Lollipop.API.Filters;

namespace Lollipop.API.Controllers
{
    [CORSActionFilter]
    [ApiController]
    [Route("[controller]/[action]")]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Create([FromBody] UserCreateCommand command) =>
            Ok(await _mediator.Send(command));

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogIn([FromBody] UserLogInCommand command) =>

            Ok(await _mediator.Send(command));

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> LogOut([FromQuery] UserLogOutCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> ChangeEmail([FromBody] UserChangeEmailCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpPatch]
        public async Task<IActionResult> ChangePassword([FromBody] UserChangePasswordCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpDelete]
        public async Task<IActionResult> DeleteAccount([FromQuery] UserDeleteAccountCommand command) =>
            Ok(await _mediator.Send(command));

        [HttpGet]
        public async Task<IActionResult> GetAllUsers([FromQuery] GetAllUsersQuery query) =>
           Ok(await _mediator.Send(query));

        [HttpGet]
        public async Task<IActionResult> GetRoles([FromQuery] GetUserRolesQuery query) =>
            Ok(await _mediator.Send(query));
    }
}
