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
    using Lollipop.Application.Advertisement.Validators;
    using FluentValidation;

    public class UpdateAdvertisementCommand : IRequest<int>
    {
        public int Id { get; init; }
        public string title { get; set; }
        public string content { get; set; }
        public IEnumerable<Category> categories { get; set; }
        public IEnumerable<Keyword> keywords { get; set; }
        public class Handler : IRequestHandler<UpdateAdvertisementCommand, int>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(UpdateAdvertisementCommand request, CancellationToken cancellationToken)
            {
                await new UpdateAdvertisementValidator().ValidateAndThrowAsync(request, cancellationToken);
                Advertisement toUpdate = await _repository.GetByIdAsync(request.Id);
                toUpdate.SetTitle(request.title);
                toUpdate.SetContent(request.content);
                await _repository.UpdateAsync(toUpdate);
                return toUpdate.Id;
            }
        }
    }
}
