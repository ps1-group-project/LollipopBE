namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class DeleteImageValidator : AbstractValidator<DeleteImageCommand>
    {
        public DeleteImageValidator()
        {
            RuleFor(x => x.AdvertId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement id cannot be null");
            RuleFor(x => x.ImageId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("image id cannot be null");
        }
    }
}
