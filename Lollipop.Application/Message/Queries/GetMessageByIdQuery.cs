namespace Lollipop.Application.Message.Queries
{
    using MediatR;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;
    public class GetMessageByIdQuery : IRequest<Message>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<GetMessageByIdQuery, Message>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<Message> Handle(GetMessageByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.Id);
            }
        }

    }
}
