namespace Lollipop.Application.Advertisement.Queries
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading.Tasks;
    using MediatR;
    using Lollipop.Core.Models;
    using System.Threading;
    using Lollipop.Application.Repository;

    public class GetAdvertisementByIdQuery : IRequest<Advertisement>
    {
        public int Id { get; init; }
        public class Handler : IRequestHandler<GetAdvertisementByIdQuery, Advertisement>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<Advertisement> Handle(GetAdvertisementByIdQuery request, CancellationToken cancellationToken)
            {
                return await _repository.GetByIdAsync(request.Id);
            }
        }
    }
}
