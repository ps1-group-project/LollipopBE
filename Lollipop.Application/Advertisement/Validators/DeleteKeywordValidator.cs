namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class DeleteKeywordValidator : AbstractValidator<AddNewKeywordCommand>
    {
        public DeleteKeywordValidator()
        {
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id not known")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id cannot be less than 0");
        }
    }
}