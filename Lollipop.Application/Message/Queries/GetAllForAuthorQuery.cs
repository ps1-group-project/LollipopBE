namespace Lollipop.Application.Message.Queries
{
    using MediatR;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;
    public class GetAllForAuthorQuery : IRequest<IEnumerable<Message>>
    {
        public string AuthorId { get; set; }
        public class Handler : IRequestHandler<GetAllForAuthorQuery, IEnumerable<Message>>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Message>> Handle(GetAllForAuthorQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetAll(m => m.AuthorId == request.AuthorId);
            }
        }
    }
}
