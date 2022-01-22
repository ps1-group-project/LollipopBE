namespace Lollipop.Application.Advertisement.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Advertisement.Validators;
    using FluentValidation;

    public class DeleteAdvertKeywordCommand : IRequest<int>
    {
        public int AdvertId { get; set; }
        public int KeywordId { get; set; }
        public class Handler : IRequestHandler<DeleteAdvertKeywordCommand, int>
        {
            private readonly IRepository<Advertisement> _advertisementRepository;
            private readonly IRepository<Keyword> _keywordRepository;
            public Handler(IRepository<Advertisement> advertisementRepository, IRepository<Keyword> keywordRepository)
            {
                _advertisementRepository = advertisementRepository;
                _keywordRepository = keywordRepository;
            }
            public async Task<int> Handle(DeleteAdvertKeywordCommand request, CancellationToken cancellationToken)
            {
                await new DeleteKeywordValidator().ValidateAndThrowAsync(request, cancellationToken);

                Advertisement toUpdate = await _advertisementRepository.GetByIdAsync(request.AdvertId);
                Keyword keyword = await _keywordRepository.GetByIdAsync(request.KeywordId);

                toUpdate.RemoveKeyword(keyword);
                await _advertisementRepository.UpdateAsync(toUpdate);

                return keyword.Id;
            }
        }
    }
}
