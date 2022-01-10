using AutoMapper;
using FluentValidation;
using Lollipop.Application.Service;
using Lollipop.Application.User.Validators;
using Lollipop.Core.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Lollipop.Application.User.Queries
{
    public class GetUserRolesQuery : IRequest<List<string>>
    {
        public string Id { get; init; }
        public class Handler : IRequestHandler<GetUserRolesQuery, List<string>>
        {
            private readonly IUserService _userService;

            public Handler(IUserService userservice)
            {
                _userService = userservice ?? throw new NullReferenceException(nameof(userservice));
            }
            public async Task<List<string>> Handle(GetUserRolesQuery request, CancellationToken cancellationToken)
            {
                await new GetUserRolesValidator().ValidateAndThrowAsync(request, cancellationToken);

                var roles = await _userService.GetUserRoles(request.Id);

                return roles;
            }
        }
    }
}
