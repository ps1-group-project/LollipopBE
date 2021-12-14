namespace Lollipop.Application.AttributeC.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class GetAttributeByIdQuery : IRequest<AttributeC>
    {
        public int Id { get; init; }
        public class Handler : IRequestHandler<GetAttributeByIdQuery, AttributeC>
        {
            private readonly IRepository<AttributeC> _repository;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<AttributeC> Handle(GetAttributeByIdQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(query.Id);
            }
        }
    }
}
