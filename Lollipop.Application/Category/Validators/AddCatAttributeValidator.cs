namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Commands;
    public class AddCatAttributeValidator : AbstractValidator<AddCatAttributeCommand>
    {
        public AddCatAttributeValidator()
        {
            RuleFor(x => x.CategoryId)
                .NotNull()
                .WithMessage("Category Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Category Id must be greater than or equal 0.");
            RuleFor(x => x.AttributeId)
                .NotNull()
                .WithMessage("Attribute Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Attribute Id must be greater than or equal 0.");
        }
    }
}
