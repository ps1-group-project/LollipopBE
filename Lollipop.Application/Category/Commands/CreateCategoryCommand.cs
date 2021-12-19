namespace Lollipop.Application.Category.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using FluentValidation;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;

    public class CreateCategoryCommand : IRequest<int>
    {
        public string Name { get; init; }

        public class Handler : IRequestHandler<CreateCategoryCommand, int>
        {
            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }

            
            public async Task<int> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
            {
                //await new CreateCategoryValidator().ValidateAndThrowAsync(request, cancellationToken);

                
                Category category = Category.Create(request.Name);
                await _repository.AddAsync(category);

                return category.Id;
            }
        }
    }
}
