namespace Lollipop.Application.Keyword.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class GetKeywordsQuery : IRequest<IEnumerable<Keyword>>
    {
        public class Handler : IRequestHandler<GetKeywordsQuery, IEnumerable<Keyword>>
        {
            private readonly IRepository<Keyword> _repository;

            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Keyword>> Handle(GetKeywordsQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
