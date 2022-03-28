namespace Lollipop.Application.AttributeC.Validators
{
    using FluentValidation;
    using Lollipop.Application.AttributeC.Commands;

    public class CreateAttributeValidator : AbstractValidator<CreateAttributeCommand>
    {
        public CreateAttributeValidator()
        {
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Attribute name cannot be null.");
            RuleFor(x => x.Values)
                .NotNull()
                .WithMessage("Attribute type cannot be null.");
        }
    }
}
