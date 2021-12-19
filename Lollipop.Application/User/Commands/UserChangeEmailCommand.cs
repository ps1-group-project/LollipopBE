namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Lollipop.Application.User.Validators;
    using Lollipop.Application.Service;

    public class UserChangeEmailCommand : IRequest
    {
        public string Email { get; set; }

        public class Handler : IRequestHandler<UserChangeEmailCommand>
        {
            private readonly IUserService _userService;
            
            public Handler(IUserService userService)
            {
                _userService = userService;
            }

            public async Task<Unit> Handle(UserChangeEmailCommand request, CancellationToken cancellationToken)
            {
                await new UserChangeEmailValidator().ValidateAndThrowAsync(request, cancellationToken);
                
                await _userService.ChangeEmailAsync(request.Email);

                return Unit.Value;
            }
        }
    }
}