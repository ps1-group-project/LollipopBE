namespace Lollipop.Application.Message.Validators
{
    using FluentValidation;
    using Lollipop.Application.Message.Commands;
    public class CreateMessageValidator : AbstractValidator<CreateMessageCommand> 
    {
        public CreateMessageValidator()
        {
            RuleFor(x => x.AuthorId)
                .NotNull()
                .WithMessage("AuthorId cannot be null.");
            RuleFor(x => x.TargetId)
                .NotNull()
                .WithMessage("TargetId cannot be null.");
            RuleFor(x => x.Content)
                .NotNull()
                .WithMessage("Content cannot be null.");

        }
    }
}
