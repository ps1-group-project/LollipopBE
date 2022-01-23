namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class CreateAdvertisementValidator : AbstractValidator<CreateAdvertisementCommand>
    {
        public CreateAdvertisementValidator()
        {
            RuleFor(x => x.Title)
                .NotNull()
                .WithMessage("Advertisement title cannot be null");
            RuleFor(x => x.Content)
                .NotNull()
                .WithMessage("Advertisement content cannot be null");
            RuleFor(x => x.Categories)
                .NotNull()
                .WithMessage("Advertisement must have category");
            RuleFor(x => x.UserId)
                .NotNull()
                .WithMessage("User id cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("User id cannot be negative");
        } 
    }
}
