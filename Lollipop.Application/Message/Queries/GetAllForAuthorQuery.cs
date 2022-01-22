namespace Lollipop.Application.Message.Queries
{
    using MediatR;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;
    using Lollipop.Core.Specification;

    public class GetAllForAuthorQuery : IRequest<IEnumerable<Message>>
    {
        public string AuthorId { get; set; }
        public class Handler : IRequestHandler<GetAllForAuthorQuery, IEnumerable<Message>>
        {
            private IRepository<Message> _repository;

            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Message>> Handle(GetAllForAuthorQuery request, CancellationToken cancellationToken)
            {


                return new List<Message>();//await _repository.GetAllAsync(m => m.AuthorId == request.AuthorId); to fix
            }
        }
    }
}
