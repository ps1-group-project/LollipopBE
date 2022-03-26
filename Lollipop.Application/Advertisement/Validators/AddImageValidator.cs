namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Application.Advertisement.Commands;
    public class AddImageValidator : AbstractValidator<AddImageCommand>
    {
        public AddImageValidator()
        {
            RuleFor(x => x.Path)
                .NotEmpty()
                .WithMessage("Path is null or empty.");
            RuleFor(x => x.AdvertId)
                .NotEmpty()
                .WithMessage("invalid id");
        }
    }
}
