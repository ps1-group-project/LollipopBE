namespace Lollipop.Application.Keyword.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using FluentValidation;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using Lollipop.Application.Keyword.Validators;

    public class CreateKeywordCommand : IRequest<int>
    {
        public string Content { get; init; }
        public class Handler : IRequestHandler<CreateKeywordCommand, int>
        {
            private readonly IRepository<Keyword> _repository;

            public Handler(IRepository<Keyword> repository)
            {
                _repository = repository;
            }

            public async Task<int> Handle(CreateKeywordCommand request, CancellationToken cancellationToken)
            {
                await new CreateKeywordValidator().ValidateAndThrowAsync(request, cancellationToken);

                Keyword keyword = Keyword.Create(request.Content);
                await _repository.AddAsync(keyword);

                return keyword.Id;
            }
        }
    }
}
