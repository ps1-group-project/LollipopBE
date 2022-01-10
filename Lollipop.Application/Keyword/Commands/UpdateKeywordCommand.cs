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
    using Lollipop.Application.Keyword.Validators;
    using FluentValidation;

    public class UpdateKeywordCommand : IRequest<int>
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public class Handler : IRequestHandler<UpdateKeywordCommand, int>
        {
            private readonly IRepository<Keyword> _repository;
            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(UpdateKeywordCommand request, CancellationToken cancellationToken)
            {
                await new UpdateKeywordValidator().ValidateAndThrowAsync(request, cancellationToken);
                Keyword toUpdate = await _repository.GetByIdAsync(request.Id);
                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }

    }
}
