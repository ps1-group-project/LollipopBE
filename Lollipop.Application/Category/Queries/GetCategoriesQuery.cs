namespace Lollipop.Application.Category.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class GetCategoriesQuery : IRequest<IEnumerable<Category>>
    {

        public class Handler : IRequestHandler<GetCategoriesQuery, IEnumerable<Category>>
        {
            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Category>> Handle(GetCategoriesQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAll(null, null, "Attributes,Advertisements");
            }

        }
    }
}
