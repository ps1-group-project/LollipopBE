namespace Lollipop.Application.AttributeC.Validators
{
    using FluentValidation;
    using Lollipop.Application.AttributeC.Queries;
    public class GetAttributeByIdValidator : AbstractValidator<GetAttributeByIdQuery>
    {
        public GetAttributeByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Attribute Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Attribute Id cannot be negative.");
        }
    }
}
