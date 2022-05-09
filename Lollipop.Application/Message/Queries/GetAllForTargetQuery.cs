using Lollipop.Core.Specification;

namespace Lollipop.Application.Message.Queries
{
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    public class GetAllForTargetQuery : IRequest<IEnumerable<Message>>
    {
        public string TargetId { get; set; }
        public class Handler : IRequestHandler<GetAllForTargetQuery, IEnumerable<Message>>
        {
            private readonly IRepository<Message> _repository;
            public Handler(IRepository<Message> repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Message>> Handle(GetAllForTargetQuery request, CancellationToken cancellationToken)
            {
                MessageSpecification spec = new(filterBy: new() { x => x.TargetId == request.TargetId });
                var list = await _repository.GetAllAsync(spec);

                return list;

            }
        }
    }
}

