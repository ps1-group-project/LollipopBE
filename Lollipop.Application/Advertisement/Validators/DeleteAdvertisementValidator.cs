﻿namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Commands;
    public class DeleteAdvertisementValidator : AbstractValidator<DeleteAdvertisementCommand>
    {
        public DeleteAdvertisementValidator()
        {
            RuleFor(x => x.AdvertId)
                .GreaterThanOrEqualTo(0)
                .WithMessage("Advertisement id cannot be negative");
        }
    }
}
