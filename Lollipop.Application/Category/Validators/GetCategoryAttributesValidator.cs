
namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Queries;

    public class GetCategoryAttributesValidator: AbstractValidator<GetCategoryAttributesQuery>
    {
        public GetCategoryAttributesValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Attribute id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Attribute id cannot be negative.");
        }

    }
}
