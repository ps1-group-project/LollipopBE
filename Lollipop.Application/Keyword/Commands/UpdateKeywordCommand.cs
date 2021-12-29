namespace Lollipop.Application.Keyword.Commands
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using System.Threading;

    public class UpdateKeywordCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string name { get; set; }
        public class Handler : IRequestHandler<UpdateKeywordCommand, int>
        {
            private readonly IRepository<Keyword> _repository;
            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(UpdateKeywordCommand request, CancellationToken cancellationToken)
            {
                Keyword toUpdate = await _repository.GetByIdAsync(request.Id);
                if (request.name != null) toUpdate.Name = request.name;
                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }

    }
}
