namespace Lollipop.Application.ForbiddenWord.Queries
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;

    public class GetForbiddenWordsByIdQuery : IRequest<ForbiddenWord>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetForbiddenWordsByIdQuery, ForbiddenWord>
        {
            private readonly IRepository<ForbiddenWord> _repository;
            public Handler(IRepository<ForbiddenWord> repository)
            {
                _repository = repository;
            }
            public async Task<ForbiddenWord> Handle(GetForbiddenWordsByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.Id);
            }
        }

    }
}
