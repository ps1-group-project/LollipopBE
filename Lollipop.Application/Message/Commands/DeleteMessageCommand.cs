namespace Lollipop.Application.Message.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using FluentValidation;
    using Lollipop.Application.Message.Validators;

    public class DeleteMessageCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteMessageCommand, int>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(DeleteMessageCommand request, CancellationToken cancellationToken)
            {
                await new DeleteMessageValidator().ValidateAndThrowAsync(request, cancellationToken);

                Message toDelete = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(toDelete);
                return toDelete.Id;
            }
        }

    }
}
