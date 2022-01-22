namespace Lollipop.Application.Category.Queries
{
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using Lollipop.Core.Specification;
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
                CategorySpecification specification = new(include: new() { x => x.Attributes });
                List<Category> categories = await _repository.GetAllAsync(specification);

                return categories;
            }

        }
    }
}
