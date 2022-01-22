namespace Lollipop.Application.Message.Validators
{
    using FluentValidation;
    using Lollipop.Application.Message.Commands;
    public class DeleteMessageValidator : AbstractValidator<DeleteMessageCommand>
    {
        public DeleteMessageValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Message id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Message id cannot be negative.");
        }
    }
}
