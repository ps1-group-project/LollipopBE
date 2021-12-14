﻿namespace Lollipop.Application.AttributeC.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    public class UpdateAttributeCommand : IRequest<int>
    {
        public int Id { get; init; }
        public string Name { get; init; }
        public string Type { get; init; }
        public class Handler : IRequestHandler<UpdateAttributeCommand, int>
        {
            private readonly IRepository<AttributeC> _repository;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(UpdateAttributeCommand request, CancellationToken cancellationToken)
            {
                AttributeC attribute = await _repository.GetByIdAsync(request.Id);
                attribute.Edit(request.Name, request.Type);
                await _repository.UpdateAsync(attribute);
                return attribute.Id;

            }
        }
    }
}
