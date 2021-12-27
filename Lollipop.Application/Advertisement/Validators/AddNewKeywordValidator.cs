namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class AddNewKeywordValidator : AbstractValidator<AddNewKeywordCommand>
    {
        public AddNewKeywordValidator()
        {
            RuleFor(x => x.keyword)
                .NotNull()
                .WithMessage("keyword cant be empty");
            RuleFor(x => x.Id)
                .NotNull()
                .WithMessage("Id not known")
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id cannot be less than 0");
        }
    }
}