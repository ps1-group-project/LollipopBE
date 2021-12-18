namespace Lollipop.Application.User.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using MediatR;
    using Lollipop.Application.User.Validators;
    using Lollipop.Application.Service;

    public class UserChangePasswordCommand : IRequest
    {
        public string Password { get; set; }
        public string NewPassword { get; set; }

        public class Handler : IRequestHandler<UserChangePasswordCommand>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userService)
            {
                _userService = userService;
            }
            
            public async Task<Unit> Handle(UserChangePasswordCommand request, CancellationToken cancellationToken)
            {
                await new UserChangePasswordValidator().ValidateAndThrowAsync(request, cancellationToken);
                
                await _userService.ChangePasswordAsync(request.Password, request.NewPassword);

                return Unit.Value;
            }
        }

    }
}