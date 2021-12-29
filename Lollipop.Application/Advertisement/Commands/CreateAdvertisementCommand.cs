namespace Lollipop.Application.Advertisement.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Collections.Generic;
    public class CreateAdvertisementCommand
    {
        //Command
        public record Command(int userId, string title, string content, IEnumerable<Category> categories, IEnumerable<Keyword> keywords) : IRequest<int>;

        //Handler
        public class Handler : IRequestHandler<Command, int>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(Command request, CancellationToken cancellationToken)
            {
                Advertisement advert = Advertisement.Create(request.userId, request.title, request.content);
                await _repository.AddAsync(advert);
                return advert.Id;
            }
        }
    }
}
