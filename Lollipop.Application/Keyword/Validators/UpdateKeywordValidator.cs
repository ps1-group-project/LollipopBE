namespace Lollipop.Application.Keyword.Validators
{
    using FluentValidation;
    using Lollipop.Application.Keyword.Commands;
    class UpdateKeywordValidator : AbstractValidator<UpdateKeywordCommand>
    {
        public UpdateKeywordValidator()
        {
            RuleFor(x => x.name)
                .NotEmpty()
                .WithMessage("name of Keyword cannot be empty");
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id cannot be less than 0");
        }
    }
}
