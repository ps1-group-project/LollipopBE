namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Commands;
    public class DeleteCategoryValidator : AbstractValidator<DeleteCategoryCommand>
    {
        public DeleteCategoryValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Cateegory id cannot be null.")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Category id cannot be negative.");
        }
    }
}
