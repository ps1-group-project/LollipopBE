namespace Lollipop.Application.Advertisement.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    public class GetAdvertisementsQuery : IRequest<IEnumerable<Advertisement>>
    {
        public class Handler : IRequestHandler<GetAdvertisementsQuery, IEnumerable<Advertisement>>
        {
            private readonly IRepository<Advertisement> _repository;

            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Advertisement>> Handle(GetAdvertisementsQuery query, CancellationToken cancellationToken)
            {
                return await _repository.GetAllAsync();
            }
        }
    }
}
