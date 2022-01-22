namespace Lollipop.Application.Message.Queries
{
    using MediatR;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;
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
                return new List<Message>(); //await _repository.GetAllAsync(m => m.TargetId == request.TargetId); fix that
            }
        }
    }
}
    
