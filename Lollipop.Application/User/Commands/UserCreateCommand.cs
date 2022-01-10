namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Lollipop.Application.User.Validators;
    using Lollipop.Application.Service;

    public class UserCreateCommand : IRequest
    {
        public string UserName { get; init; }
        public string Email { get; init; }
        public string Password { get; init; }
        public string PhoneNumber { get; init; }

        public class Handler : IRequestHandler<UserCreateCommand, Unit>
        {
            private readonly IUserService _userService;
            
            public Handler(IUserService userService)
            {
                _userService = userService;
            }
            
            public async Task<Unit> Handle(UserCreateCommand request, CancellationToken cancellationToken)
            {
                await new UserCreateValidator().ValidateAndThrowAsync(request, cancellationToken);
                
                await _userService.RegisterUserAsync(
                    request.UserName,
                    request.Email,
                    request.PhoneNumber,
                    request.Password);

                return Unit.Value;
            }
        }
    }
}