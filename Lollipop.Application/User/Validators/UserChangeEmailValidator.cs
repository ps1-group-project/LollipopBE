namespace Lollipop.Application.User.Validators
{
    using FluentValidation;
    using Lollipop.Application.User.Commands;

    public class UserChangeEmailValidator : AbstractValidator<UserChangeEmailCommand>
    {
        public UserChangeEmailValidator()
        {
            RuleFor(x => x.Email)
                .NotEmpty()
                .EmailAddress()
                .WithMessage("Email must be valid");
        }
    }
}