namespace Lollipop.Application.Advertisement.Commands
{
    using MediatR;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using Lollipop.Application.Advertisement.Validators;
    using FluentValidation;
    using System.Threading;
    using System.Threading.Tasks;
    public class DeleteAdvertCategoryCommand : IRequest<int>
    {
        public int AdvertId { get; init; }
        public int CategoryId { get; init; }

        public class Handler : IRequestHandler<DeleteAdvertCategoryCommand, int>
        {
            private readonly IRepository<Advertisement> _advertRepository;
            private readonly IRepository<Category> _catRepository;

            public Handler(IRepository<Advertisement> advertRepository, IRepository<Category> catRepository)
            {
                _advertRepository = advertRepository;
                _catRepository = catRepository;
            }

            public async Task<int> Handle(DeleteAdvertCategoryCommand request, CancellationToken cancellationToken)
            {
                await new DeleteAdvertCategoryValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement advertisement = await _advertRepository.GetByIdAsync(request.AdvertId);
                Category category = await _catRepository.GetByIdAsync(request.CategoryId);

                advertisement.RemoveCategory(category);
                await _advertRepository.UpdateAsync(advertisement);

                return category.Id;
            }
        }
    }
}
