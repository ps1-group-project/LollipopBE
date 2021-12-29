namespace Lollipop.Application.ForbiddenWord.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;

    public class UpdateForbiddenWordCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Word { get; set; }
        public class Handler : IRequestHandler<UpdateForbiddenWordCommand, int>
        {
            private readonly IRepository<ForbiddenWord> _repository;
            public Handler(IRepository<ForbiddenWord> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(UpdateForbiddenWordCommand request, CancellationToken cancellationToken)
            {
                ForbiddenWord toUpdate = await _repository.GetByIdAsync(request.Id);
                toUpdate.Word = request.Word;
                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }
    }
}
