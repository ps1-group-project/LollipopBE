namespace Lollipop.Application.Advertisement.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Collections.Generic;
    using Lollipop.Application.Advertisement.Validators;
    using FluentValidation;

    public class CreateAdvertisementCommand : IRequest<int>
    {
        public string UserId { get; init; }
        public string Title { get; set; }
        public string Content { get; set; }
        public int CategoryId { get; set; }
        public IEnumerable<Keyword> Keywords { get; set; }

        public class Handler : IRequestHandler<CreateAdvertisementCommand, int>
        {
            private readonly IRepository<Advertisement> _AdvRepository;
            private readonly IRepository<Category> _CatRepository;
            public Handler(IRepository<Advertisement> repository, IRepository<Category> category)
            {
                _AdvRepository = repository;
                _CatRepository = category;
            }
            public async Task<int> Handle(CreateAdvertisementCommand request, CancellationToken cancellationToken)
            {
                await new CreateAdvertisementValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement advert = Advertisement.Create(request.UserId, request.Title, request.Content);
                Category category = await _CatRepository.GetByIdAsync(request.CategoryId);
                advert.AddCategory(category);
                
                await _AdvRepository.AddAsync(advert);
                
                return advert.Id;
            }
        }
    }
}
