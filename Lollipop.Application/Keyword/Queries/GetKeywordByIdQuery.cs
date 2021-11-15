namespace Lollipop.Application.Keyword.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class GetKeywordByIdQuery : IRequest<Keyword>
    {
        public int Id { get; init; }
        public class Handler : IRequestHandler<GetKeywordByIdQuery, Keyword>
        {
            
            private readonly IRepository<Keyword> _repository;

            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }

            public async Task<Keyword> Handle(GetKeywordByIdQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(query.Id);

            }
        }
    }
}
