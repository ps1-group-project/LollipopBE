namespace Lollipop.Application.User.Validators
{
    using FluentValidation;
    using Lollipop.Application.User.Commands;

    public class UserLogInValidator : AbstractValidator<UserLogInCommand>
    {
        public UserLogInValidator()
        {
            RuleFor(x => x.UserName)
                .NotNull()
                .NotEmpty()
                .WithMessage("UserName cannot be empty.");
            RuleFor(x => x.Password)
                .NotNull()
                .NotEmpty()
                .WithMessage("Password cannot be empty.");
        }
    }
}