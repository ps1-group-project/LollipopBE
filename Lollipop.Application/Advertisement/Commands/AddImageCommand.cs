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

    /// <summary>
    /// Add image to advertisement, returns id of image >0 if succesful
    /// </summary>
    public class AddImageCommand : IRequest<int>
    {
        public int AdvertId { get; init; }
        /// <summary>
        /// Path to file
        /// </summary>
        public string Path { get; init; }

        public class Handler : IRequestHandler<AddImageCommand, int>
        {
            private readonly IRepository<Advertisement> _advertisementRepository;
            private readonly IRepository<AdvImage> _imageRepository;
            public Handler(IRepository<Advertisement> advrepository, IRepository<AdvImage> imrepository)
            {
                _advertisementRepository = advrepository;
                _imageRepository = imrepository;
            }
            public async Task<int> Handle(AddImageCommand request, CancellationToken cancellationToken)
            {
                await new AddImageValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement advert = await _advertisementRepository.GetByIdAsync(request.AdvertId) 
                    ?? throw new EntityNotFoundException(typeof(Advertisement), request.AdvertId);

                AdvImage image = new AdvImage();
                string base64img = Base64StringHelper.ToBase64String(request.Path);

                if (String.IsNullOrWhiteSpace(base64img)){
                    return 0;
                }

                image.Base64String = base64img;
                advert.AddImage(image);
                await _advertisementRepository.UpdateAsync(advert);

                return image.Id;
            }
        }
    }
}
