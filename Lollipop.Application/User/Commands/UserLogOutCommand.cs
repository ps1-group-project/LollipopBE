namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Lollipop.Application.Service;

    public class UserLogOutCommand : IRequest
    {
        public class Handler : IRequestHandler<UserLogOutCommand, Unit>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }
            
            public async Task<Unit> Handle(UserLogOutCommand request, CancellationToken cancellationToken)
            {
                await _userService.SingOutAsync();

                return Unit.Value;
            }
        }
    }
}