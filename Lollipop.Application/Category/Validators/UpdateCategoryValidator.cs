namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Commands;
    public class UpdateCategoryValidator : AbstractValidator<UpdateCategoryCommand>
    {
        public UpdateCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Category id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Category id cannot be negative.");
            RuleFor(x => x.Name)
                .NotNull()
                .WithMessage("Category name cannot be null.");
        }
    }
}
