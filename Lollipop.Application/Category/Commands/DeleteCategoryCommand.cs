namespace Lollipop.Application.Category.Commands
{
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Linq;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCategoryCommand : IRequest<int>
    {
        public int Id { get; init; }

        public class Handler : IRequestHandler<DeleteCategoryCommand, int>
        {
            private readonly IRepository<Category> _repository;

            public Handler(IRepository<Category> repository)
            {
                _repository = repository;
            }


            public async Task<int> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
            {
                //await new DeleteCategoryValidator().ValidateAndThrowAsync(request, cancellationToken);

                Category category = (await _repository.GetAll(c => c.Id == request.Id, null, "Attributes,Advertisements")).Single();
                await _repository.DeleteAsync(category);

                return category.Id;
            }
        }
    }
}
