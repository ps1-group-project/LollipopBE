namespace Lollipop.Application.Advertisement.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Collections.Generic;
    public class CreateAdvertisementCommand : IRequest<int>
    {
        public int userId { get; init; }
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Keyword> keywords { get; set; }

        public class Handler : IRequestHandler<CreateAdvertisementCommand, int>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
            {
                Advertisement advert = Advertisement.Create(request.userId, request.title, request.content);
                await _repository.AddAsync(advert);
                return advert.Id;
            }
        }
    }
}
