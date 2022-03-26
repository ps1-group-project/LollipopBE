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
    using Lollipop.Application.Exceptions;
    using Lollipop.Application.Helpers;
    using Lollipop.Core.Specification;

    public class GetAdvertisementImagesQuery : IRequest<List<AdvImage>>
    {
        public int AdvertId { get; init; }

        public class Handler : IRequestHandler<GetAdvertisementImagesQuery, List<AdvImage>>
        {
            private readonly IRepository<Advertisement> _advertisementRepository;
            private readonly IRepository<AdvImage> _imageRepository;
            public Handler(IRepository<Advertisement> advrepository, IRepository<AdvImage> imrepository)
            {
                _advertisementRepository = advrepository;
                _imageRepository = imrepository;
            }
            public async Task<List<AdvImage>> Handle(GetAdvertisementImagesQuery request, CancellationToken cancellationToken)
            {
                await new GetAdvertisementImagesValidator().ValidateAndThrowAsync(request, cancellationToken);

                AdvertisementSpecification specification = new(include: new() { x => x.Images });

                Advertisement advert = await _advertisementRepository.GetByIdAsync(request.AdvertId, specification )
                    ?? throw new EntityNotFoundException(typeof(Advertisement), request.AdvertId);

                List<AdvImage> images = new List<AdvImage>(advert.Images);

                return images;
            }
        }
    }
}
