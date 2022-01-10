namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class CreateAdvertisementValidator : AbstractValidator<CreateAdvertisementCommand>
    {
        public CreateAdvertisementValidator()
        {
            RuleFor(x => x.title)
                .NotNull()
                .WithMessage("Advertisement title cannot be null");
            RuleFor(x => x.content)
                .NotNull()
                .WithMessage("Advertisement content cannot be null");
            RuleFor(x => x.categories)
                .NotNull()
                .WithMessage("Advertisement must have category");
            RuleFor(x => x.userId)
                .NotNull()
                .WithMessage("User id cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("User id cannot be negative");
        } 
    }
}
