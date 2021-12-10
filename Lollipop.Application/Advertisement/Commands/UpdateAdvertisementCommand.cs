namespace Lollipop.Application.Advertisement.Commands
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using MediatR;
    using Lollipop.Core.Models;
    using Lollipop.Application.Repository;

    public class UpdateAdvertisementCommand : IRequest<int>
    {
        //Command
        public record Command(int Id, string title, string content, IEnumerable<Category> categories, IEnumerable<Keyword> keywords) : IRequest<int>;

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
                Advertisement toUpdate = await _repository.GetByIdAsync(request.Id);
                toUpdate.Title = request.title;
                toUpdate.Content = request.content;
                toUpdate.Categories = request.categories;
                toUpdate.Keywords = request.keywords;
                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }
    }
}
