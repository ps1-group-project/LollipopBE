namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class UpdateAdvertisementValidator : AbstractValidator<UpdateAdvertisementCommand>
    {
        public UpdateAdvertisementValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement Id cannot be negative");
        }
    }
}
