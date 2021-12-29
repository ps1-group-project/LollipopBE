namespace Lollipop.Application.ForbiddenWord.Commands
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
    public class DeleteForbiddenWordByIdCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteForbiddenWordByIdCommand,int>
        {
            private readonly IRepository<ForbiddenWord> _repository;
            public Handler(IRepository<ForbiddenWord> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(DeleteForbiddenWordByIdCommand request, CancellationToken cancellationToken)
            {
                ForbiddenWord toDelete = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(toDelete);
                return toDelete.Id;
            }
        }
    }
}
