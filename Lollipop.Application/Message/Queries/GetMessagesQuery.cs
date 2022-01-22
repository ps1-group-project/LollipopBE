namespace Lollipop.Application.Message.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;

    public class GetMessagesQuery : IRequest<IEnumerable<Message>>
    {
        public class Handler : IRequestHandler<GetMessagesQuery, IEnumerable<Message>>
        {
            private readonly IRepository<Message> _repository;

            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Message>> Handle(GetMessagesQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAll();
            }
        }
    }
}
