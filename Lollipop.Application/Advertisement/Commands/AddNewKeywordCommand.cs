namespace Lollipop.Application.Advertisement.Commands
{
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using FluentValidation;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;
    using System.Collections.Generic;
    using Lollipop.Application.Advertisement.Validators;
    public class AddNewKeywordCommand : IRequest<int>
    {
        public int Id{get;set;}
        public Keyword keyword{get;set;}

        public class Handler : IRequestHandler<AddNewKeywordCommand, int>
        {
            private readonly IRepository<Advertisement> _repository;

            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }

            
            public async Task<int> Handle(AddNewKeywordCommand request, CancellationToken cancellationToken)
            {
                await new AddNewKeywordValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement advert = await _repository.GetByIdAsync(request.Id);
                advert.AddKeyword(request.keyword);
                await _repository.UpdateAsync(advert);
                
                return advert.Id;
            }
        }
    }
}