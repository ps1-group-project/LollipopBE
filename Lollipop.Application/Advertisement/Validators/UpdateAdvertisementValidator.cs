namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class UpdateAdvertisementValidator : AbstractValidator<UpdateAdvertisementCommand>
    {
        public UpdateAdvertisementValidator()
        {
            RuleFor(x => x.AdvertId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement Id cannot be negative");
        }
    }
}
