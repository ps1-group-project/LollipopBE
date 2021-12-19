namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Lollipop.Application.User.Validators;
    using Lollipop.Application.Service;

    public class UserLogInCommand : IRequest
    {
        public string UserName { get; init; }
        
        public string Password { get; init; }
        
        //public bool RememberMe { get; init; }
        
        public class Handler : IRequestHandler<UserLogInCommand, Unit>
        {
            private readonly IUserService _userService;
            
            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Unit> Handle(UserLogInCommand request, CancellationToken cancellationToken)
            {
                await new UserLogInValidator().ValidateAndThrowAsync(request, cancellationToken);

                await _userService.PasswordSignInAsync(request.UserName, request.Password, false);

                return Unit.Value;
            }
        }
    }
}