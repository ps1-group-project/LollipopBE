namespace Lollipop.Application.User.Validators
{
    using FluentValidation;
    using Lollipop.Application.User.Commands;

    public class UserChangePasswordValidator : AbstractValidator<UserChangePasswordCommand>
    {
        public UserChangePasswordValidator()
        {
            RuleFor(x => x.NewPassword)
                .MinimumLength(8)//polecam zaq1@WSX do testow
                .Matches("^(?=.[A-Za-z])(?=.\\d)(?=.[@$!%#?&])[A-Za-z\\d@$!%*#?&]{8,}$")
                .WithMessage("Password must have at least one number, uppercase, lowercase, special character");
        }
    }
}