namespace Lollipop.Application.Advertisement.Validators
{
    using FluentValidation;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Application.Advertisement.Commands;
    public class DeleteKeywordValidator : AbstractValidator<DeleteAdvertKeywordCommand>
    {
        public DeleteKeywordValidator()
        {
            RuleFor(x => x.KeywordId)
                .NotNull()
                .WithMessage("KeywordId cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("KeywordId must be equal or greater than 0");
            RuleFor(x => x.AdvertId)
                .NotNull()
                .WithMessage("AdvertId cannot be null")
                .GreaterThanOrEqualTo(0)
                .WithMessage("AdvertId must be equal or greater than 0");
        }
    }
}
