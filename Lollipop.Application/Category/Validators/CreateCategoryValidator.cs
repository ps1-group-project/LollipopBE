namespace Lollipop.Application.Category.Validators
{
    using FluentValidation;
    using Lollipop.Application.Category.Commands;
    public class CreateCategoryValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryValidator()
        {
            RuleFor(x => x.Name)
                    .NotNull()
                    .WithMessage("Category name cannot be null.");
        }
    }
}
