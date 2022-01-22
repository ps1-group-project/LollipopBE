namespace Lollipop.Application.Category.Queries
{
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Application.Category.Validators;
    using FluentValidation;
    using Lollipop.Core.Models;
    using MediatR;
    using Lollipop.Core.Specification;

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
                await new GetCategoryByIdValidator().ValidateAndThrowAsync(query, cancellationToken);

                CategorySpecification specification = new(include: new() { x => x.Attributes });
                specification.SetFilterCondition(x => x.Id == query.Id);

                return (await _repository.GetAllAsync(specification)).FirstOrDefault();

            }
        }
    }
}
