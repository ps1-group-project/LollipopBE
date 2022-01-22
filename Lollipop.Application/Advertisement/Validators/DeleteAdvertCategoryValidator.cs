namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class DeleteAdvertCategoryValidator : AbstractValidator<DeleteAdvertCategoryCommand>
    {
        public DeleteAdvertCategoryValidator()
        {
            RuleFor(x => x.AdvertId)
                .NotNull()
                .WithMessage("Advertisement Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement Id cannot be negative.");
            RuleFor(x => x.CategoryId)
                .NotNull()
                .WithMessage("Category Id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Category Id cannot be negative.");
        }
    }
}
