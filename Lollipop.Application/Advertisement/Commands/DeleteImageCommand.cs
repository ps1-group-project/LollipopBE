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
    using System.Linq;
    using Lollipop.Core.Specification;

    /// <summary>
    /// remove image from advertisement, returns id of image >0 if succesful
    /// </summary>
    public class DeleteImageCommand : IRequest<int>
    {
        public int AdvertId { get; init; }
        public int ImageId { get; init; }

        public class Handler : IRequestHandler<DeleteImageCommand, int>
        {
            private readonly IRepository<Advertisement> _advertisementRepository;
            private readonly IRepository<AdvImage> _imageRepository;
            public Handler(IRepository<Advertisement> advrepository, IRepository<AdvImage> imrepository)
            {
                _advertisementRepository = advrepository;
                _imageRepository = imrepository;
            }
            public async Task<int> Handle(DeleteImageCommand request, CancellationToken cancellationToken)
            {
                await new DeleteImageValidator().ValidateAndThrowAsync(request, cancellationToken);

                AdvertisementSpecification specification = new(include: new() { x => x.Images });

                Advertisement advert = await _advertisementRepository.GetByIdAsync(request.AdvertId)
                    ?? throw new EntityNotFoundException(typeof(Advertisement), request.AdvertId);

                AdvImage advImage = advert.Images.FirstOrDefault(x => x.Id == request.ImageId);
                if (advImage == null) return 0;
                advert.RemoveImage(advImage);
                await _advertisementRepository.UpdateAsync(advert);

                return advImage.Id;
            }
        }
    }
}
