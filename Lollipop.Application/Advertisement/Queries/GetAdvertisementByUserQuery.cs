namespace Lollipop.Application.Advertisement.Queries
{
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;

    public class GetAdvertisementByUserQuery : IRequest<IEnumerable<Advertisement>>
    {
        public string Id { get; init; }

        public class Handler : IRequestHandler<GetAdvertisementByUserQuery, IEnumerable<Advertisement>>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<IEnumerable<Advertisement>> Handle(GetAdvertisementByUserQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Advertisement> adverts =  await _repository.GetAllAsync();

                return adverts.Where(x => x.UserId == request.Id);
            }
        }
    }
}
