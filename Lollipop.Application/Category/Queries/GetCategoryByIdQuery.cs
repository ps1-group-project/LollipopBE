namespace Lollipop.Application.Category.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public int Id { get; init; }

        public class Handler : IRequestHandler<GetCategoryByIdQuery, Category>
        {

            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            public async Task<Category> Handle(GetCategoryByIdQuery query, CancellationToken cancellationToken)
            {
                //return await _repository.GetByIdAsync(query.Id);
                return (await _repository.GetAll(c => c.Id == query.Id, null, "Attributes,Advertisements")).Single();

            }
        }
    }
}
