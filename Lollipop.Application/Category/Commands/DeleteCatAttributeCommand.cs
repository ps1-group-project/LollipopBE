namespace Lollipop.Application.Category.Commands
{
    using MediatR;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using Lollipop.Application.Category.Validators;
    using FluentValidation;
    using System.Threading;
    using System.Threading.Tasks;

    public class DeleteCatAttributeCommand : IRequest<int>
    {
        public int CategoryId { get; init; }
        public int AttributeId { get; init; }
        public class Handler : IRequestHandler<DeleteCatAttributeCommand, int>
        {
            private readonly IRepository<AttributeC> _attributeRepository;
            private readonly IRepository<Category> _catRepository;

            public Handler(IRepository<AttributeC> attributeRepository, IRepository<Category> catRepository)
            {
                _attributeRepository = attributeRepository;
                _catRepository = catRepository;
            }

            public async Task<int> Handle(DeleteCatAttributeCommand request, CancellationToken cancellationToken)
            {
                await new DeleteCatAttributeValidator().ValidateAndThrowAsync(request, cancellationToken);

                AttributeC attribute = await _attributeRepository.GetByIdAsync(request.AttributeId);
                Category category = await _catRepository.GetByIdAsync(request.CategoryId);

                category.RemoveAttribute(attribute);
                await _catRepository.UpdateAsync(category);

                return category.Id;
            }
        }
    }
}
