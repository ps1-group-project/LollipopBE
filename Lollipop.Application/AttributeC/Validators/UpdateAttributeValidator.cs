namespace Lollipop.Application.AttributeC.Validators
{
    using FluentValidation;
    using Lollipop.Application.AttributeC.Commands;
    public class UpdateAttributeValidator : AbstractValidator<UpdateAttributeCommand>
    {
        public UpdateAttributeValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Attribute Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Attribute Id cannot be negative.");
        }
    }
}
