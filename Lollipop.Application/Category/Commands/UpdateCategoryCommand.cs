namespace Lollipop.Application.Category.Commands
{
    using MediatR;
    using System.Threading;
    using System.Threading.Tasks;
    using FluentValidation;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;
    using System.Linq;

    public class UpdateCategoryCommand : IRequest<int>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public IEnumerable<AttributeC> Attributes { get; init; }
        public class Handler : IRequestHandler<UpdateCategoryCommand, int>
        {
            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }


            public async Task<int> Handle(UpdateCategoryCommand request, CancellationToken cancellationToken)
            {
                //await new UpdateCategoryValidator().ValidateAndThrowAsync(request, cancellationToken);
                Category category = (await _repository.GetAll(c=>c.Id == request.Id, null, "Attributes,Advertisements")).Single(); 
                category.Edit(request.Name, request.Attributes);

                await _repository.UpdateAsync(category);

                return category.Id;
            }
        }
    }
}
