namespace Lollipop.Application.User.Validators
{
    using FluentValidation;
    using Lollipop.Application.User.Commands;

    public class UserCreateValidator : AbstractValidator<UserCreateCommand>
    {
        public UserCreateValidator()
        {
            
            RuleFor(x => x.UserName)
                .NotEmpty()
                .WithMessage("Username cannot be null");

            RuleFor(x => x.Email)
                .NotEmpty()
                .WithMessage("Email cannot be null");

            RuleFor(x => x.PhoneNumber)
                .NotEmpty()
                .WithMessage("PhoneNumber cannot be null");

            RuleFor(x => x.Password)
                .NotEmpty()
                .WithMessage("Password cannot be null");
        }
    }
}