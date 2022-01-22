namespace Lollipop.Application.ForbiddenWord.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    public class GetForbiddenWordsQuery : IRequest<IEnumerable<ForbiddenWord>>
    {
        public class Handler : IRequestHandler<GetForbiddenWordsQuery, IEnumerable<ForbiddenWord>>
        {
            private readonly IRepository<ForbiddenWord> _repository;

            public Handler(IRepository<ForbiddenWord> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<ForbiddenWord>> Handle(GetForbiddenWordsQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
