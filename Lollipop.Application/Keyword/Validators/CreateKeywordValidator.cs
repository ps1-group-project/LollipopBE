namespace Lollipop.Application.Keyword.Validators
{
    using FluentValidation;
    using Lollipop.Application.Keyword.Commands;

    public class CreateKeywordValidator : AbstractValidator<CreateKeywordCommand> 
    {
        public CreateKeywordValidator()
        {
            RuleFor(x => x.Content)
                .NotEmpty()
                .WithMessage("Content cant be empty");
        }
    }
}
