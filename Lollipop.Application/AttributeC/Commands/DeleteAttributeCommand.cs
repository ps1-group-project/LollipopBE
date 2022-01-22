namespace Lollipop.Application.AttributeC.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Application.AttributeC.Validators;
    using FluentValidation;
    using Lollipop.Core.Models;
    using MediatR;
    public class DeleteAttributeCommand : IRequest<int>
    {
        public int Id { get; init; }
        public class Handler : IRequestHandler<DeleteAttributeCommand, int>
        {
            private readonly IRepository<AttributeC> _repository;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(DeleteAttributeCommand request, CancellationToken cancellationToken)
            {
                await new DeleteAttributeValidator().ValidateAndThrowAsync(request, cancellationToken);

                AttributeC attributeToDelete  = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(attributeToDelete);
                return attributeToDelete.Id;
            }
        }
    }
}
