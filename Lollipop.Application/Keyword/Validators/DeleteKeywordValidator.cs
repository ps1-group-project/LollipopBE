namespace Lollipop.Application.Keyword.Validators
{
    using FluentValidation;
    using Lollipop.Application.Keyword.Commands;
    class DeleteKeywordValidator : AbstractValidator<DeleteKeywordCommand>
    {
        public DeleteKeywordValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Id value cannot be less than 0");
        }
    }
}
