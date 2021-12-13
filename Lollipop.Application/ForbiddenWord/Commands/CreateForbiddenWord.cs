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

    public class CreateForbiddenWord : IRequest<int>
    {
        public string word { get; set; }
        public class Handler : IRequestHandler<CreateForbiddenWord, int>
        {
            private readonly IRepository<ForbiddenWord> _repository;
            public Handler(IRepository<ForbiddenWord> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(CreateForbiddenWord request, CancellationToken cancellationToken)
            {
                ForbiddenWord word = ForbiddenWord.Create(request.word);
                await _repository.AddAsync(word);
                return word.Id;
            }
        }
    }
}
