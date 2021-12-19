namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Lollipop.Application.Service;

    public class UserDeleteAccountCommand : IRequest
    {
        public class Handler : IRequestHandler<UserDeleteAccountCommand>
        {
            private readonly IUserService _userService;
            public Handler(IUserService userService)
            {
                _userService = userService;
            }
            
            public async Task<Unit> Handle(UserDeleteAccountCommand request, CancellationToken cancellationToken)
            {
                await _userService.DeleteUserAsync();
                
                return Unit.Value;
            }
        }
    }
}