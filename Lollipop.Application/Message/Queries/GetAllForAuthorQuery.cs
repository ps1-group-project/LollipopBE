namespace Lollipop.Application.Message.Queries
{
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using Lollipop.Core.Specification;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

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
                MessageSpecification spec = new(filterBy: new() { x => x.AuthorId == request.AuthorId });
                var list = await _repository.GetAllAsync(spec);

                return list;
            }
        }
    }
}
