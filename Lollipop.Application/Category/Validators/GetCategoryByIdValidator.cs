namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Queries;
    public class GetCategoryByIdValidator : AbstractValidator<GetCategoryByIdQuery>
    {
        public GetCategoryByIdValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Category id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Category id cannot be negative.");
        }
    }
}
