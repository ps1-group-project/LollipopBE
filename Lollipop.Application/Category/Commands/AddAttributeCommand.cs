using System.Threading;
using System.Threading.Tasks;
using MediatR;
using FluentValidation;
using Lollipop.Application.Repository;
using Lollipop.Core.Models;
using System;

namespace MeetMap.Application.Category.Commands
{
    public class AddAttributeCommand : IRequest
    {
        public int CategoryId { get; init; }
        public int AttributeId { get; init; }

        public class Handler : IRequestHandler<AddAttributeCommand>
        {
            private readonly IRepository<Lollipop.Core.Models.Category> _categoryRepository;
            private readonly IRepository<AttributeC> _attributeRepository;

            public Handler(IRepository<Lollipop.Core.Models.Category> categoryRepository, IRepository<AttributeC> attribute)
            {
                _categoryRepository = categoryRepository;
                _attributeRepository = attribute;
            }
            public async Task<Unit> Handle(AddAttributeCommand request, CancellationToken cancellationToken)
            {

                Lollipop.Core.Models.Category category = await _categoryRepository.GetByIdAsync(request.CategoryId);
                AttributeC attr = await _attributeRepository.GetByIdAsync(request.AttributeId);
                category.AddAttribute(attr);
                await _categoryRepository.UpdateAsync(category);

                return Unit.Value;
            }
        }
    }
}
