namespace Lollipop.Application.AttributeC.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    public class GetAttributesCQuery : IRequest<IEnumerable<AttributeC>>
    {
        public class Handler : IRequestHandler<GetAttributesCQuery, IEnumerable<AttributeC>>
        {
            private readonly IRepository<AttributeC> _repository;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<AttributeC>> Handle(GetAttributesCQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
