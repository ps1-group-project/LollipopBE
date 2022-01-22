namespace Lollipop.Application.AttributeC.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Application.AttributeC.Validators;
    using Lollipop.Core.Models;
    using FluentValidation;
    using MediatR;
    public class CreateAttributeCommand : IRequest<int>
    {
        public string Name { get; init; }
        public string Type { get; init; }
        public class Handler : IRequestHandler<CreateAttributeCommand, int>
        {
            private readonly IRepository<AttributeC> _repository;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(CreateAttributeCommand request, CancellationToken cancellationToken)
            {
                await new CreateAttributeValidator().ValidateAndThrowAsync(request, cancellationToken);

                AttributeC attribute = AttributeC.Create(request.Name, request.Type);
                await _repository.AddAsync(attribute);
                return attribute.Id;
                
            }
        }
    }
}
