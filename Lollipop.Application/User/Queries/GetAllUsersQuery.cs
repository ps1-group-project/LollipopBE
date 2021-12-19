using AutoMapper;
using Lollipop.Application.DataTransferClasses;
using Lollipop.Application.Service;
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
    public class GetAllUsersQuery : IRequest<List<UserDto>>
    {
        public class Handler : IRequestHandler<GetAllUsersQuery, List<UserDto>>
        {
            private readonly IUserService _userService;
            private readonly IMapper _mapper;

            public Handler(IUserService userservice, IMapper mapper)
            {
                _userService = userservice ?? throw new NullReferenceException(nameof(userservice));
                _mapper = mapper ?? throw new NullReferenceException(nameof(mapper));
            }
            public async Task<List<UserDto>> Handle(GetAllUsersQuery request, CancellationToken cancellationToken)
            {
                List<AppUser> users = await _userService.GetAllUsersAsync();

                return _mapper.Map<List<UserDto>>(users);
            }
        }
    }
}
