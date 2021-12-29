namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    class DeleteAdvertisementValidator : AbstractValidator<DeleteAdvertisementCommand>
    {
        public DeleteAdvertisementValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement id cannot be negative");
        }
    }
}
