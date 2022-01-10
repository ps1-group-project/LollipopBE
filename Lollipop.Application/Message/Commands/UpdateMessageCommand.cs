namespace Lollipop.Application.Message.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;

    public class UpdateMessageCommand : IRequest<int>
    {
        public int Id { get; init; }
        public string AuthorId { get; init; }
        public string TargetId { get; init; }
        public string Content { get; init; }
        public class Handler : IRequestHandler<UpdateMessageCommand, int>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(UpdateMessageCommand request, CancellationToken cancellationToken)
            {
                Message toUpdate = await _repository.GetByIdAsync(request.Id);
                toUpdate.Edit(request.AuthorId, request.TargetId, request.Content);

                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }
    }
}
