namespace Lollipop.Application.Advertisement.Commands
{
    using FluentValidation;
    using Lollipop.Application.Advertisement.Validators;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;

    public class CreateAdvertisementCommand : IRequest<int>
    {
        public string UserId { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public IEnumerable<int> Categories { get; set; }
        public IEnumerable<Keyword> Keywords { get; set; }

        public class Handler : IRequestHandler<CreateAdvertisementCommand, int>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
            {
                await new CreateAdvertisementValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement advert = Advertisement.Create(request.UserId, request.Title, request.Content);

                foreach (var category in request.Categories)
                {
                    advert.AddCategory(category);
                }
                foreach (var keyword in request.Keywords)
                {
                    advert.AddKeyword(keyword);
                }

                await _repository.AddAsync(advert);

                return advert.Id;
            }
        }
    }
}
