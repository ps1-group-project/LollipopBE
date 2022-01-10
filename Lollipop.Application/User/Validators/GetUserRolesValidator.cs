using FluentValidation;
using Lollipop.Application.User.Queries;

namespace Lollipop.Application.User.Validators
{
    public class GetUserRolesValidator : AbstractValidator<GetUserRolesQuery>
    {
        public GetUserRolesValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty()
                .WithMessage("User Id cant be empty");
        }
    }
}
