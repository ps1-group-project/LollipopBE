namespace Lollipop.Application.AttributeC.Validators
{
    using FluentValidation;
    using Lollipop.Application.AttributeC.Commands;
    public class DeleteAttributeValidator : AbstractValidator<DeleteAttributeCommand>
    {
        public DeleteAttributeValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Attribute Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Attribute Id cannot be negative.");
        }
    }
}
