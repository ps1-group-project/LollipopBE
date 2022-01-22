namespace Lollipop.Application.Message.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using FluentValidation;
    using Lollipop.Application.Message.Validators;

    public class CreateMessageCommand : IRequest<int>
    {
        public string AuthorId { get; init; }
        public string TargetId { get; init; }
        public string Content { get; init; }
        public class Handler : IRequestHandler<CreateMessageCommand, int>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(CreateMessageCommand request, CancellationToken cancellationToken)
            {
                await new CreateMessageValidator().ValidateAndThrowAsync(request, cancellationToken);

                Message message = Message.Create(request.AuthorId, request.TargetId, request.Content);
                await _repository.AddAsync(message);
                return message.Id;
            }
        }
    }
}
