

namespace Lollipop.Application.Category.Queries
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Category.Validators;
    using FluentValidation;

    public class GetCategoryAttributesQuery : IRequest<IEnumerable<AttributeC>>
    {
        public int Id { get; init; }

        public class Handler : IRequestHandler<GetCategoryAttributesQuery, IEnumerable<AttributeC>>
        {

            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<AttributeC>> Handle(GetCategoryAttributesQuery query, CancellationToken cancellationToken)
            {
                await new GetCategoryAttributesValidator().ValidateAndThrowAsync(query, cancellationToken);

                Category category = await _repository.GetByIdAsync(query.Id);

                return category.GetAllAttributes();

            }
        }
    }
}
