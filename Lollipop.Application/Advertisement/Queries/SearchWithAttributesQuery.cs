

using System.Linq;

namespace Lollipop.Application.Advertisement.Queries
{
    using MediatR;
    using System.Collections.Generic;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;

    public class SearchWithAttributesQuery : IRequest<List<Advertisement>>
    {
        public IEnumerable<AttributeC> attributes { get; init; }
        public string Query { get; init; }
        
        public class Handler : IRequestHandler<SearchWithAttributesQuery, List<Advertisement>>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<List<Advertisement>> Handle(SearchWithAttributesQuery request, CancellationToken cancellationToken)
            {
                IEnumerable<Advertisement> AllAdverts = await _repository.GetAllAsync();
                List<Advertisement> searchResults = new List<Advertisement>();

                foreach (Advertisement advert in AllAdverts)
                {
                    if (advert.Title.Contains(request.Query))
                    {
                        searchResults.Add(advert);
                    }
                }

                foreach (Advertisement advert in searchResults)
                {
                    foreach (AttributeC attribute in request.attributes)
                    {
                        
                    }
                        
                }

                return searchResults;
            }
        }
    }
}