namespace Lollipop.Application.Keyword.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    public class DeleteKeywordCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteKeywordCommand, int>
        {
            private readonly IRepository<Keyword> _repository;
            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(DeleteKeywordCommand request, CancellationToken cancellationToken)
            {
                Keyword toDelete = await _repository.GetByIdAsync(request.Id);
                _repository.DeleteAsync(toDelete);
                return toDelete.Id;
            }
        }
    }
}
