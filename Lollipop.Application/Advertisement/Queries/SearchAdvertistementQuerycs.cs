using System.Linq;

namespace Lollipop.Application.Advertisement.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    public class SearchAdvertistementQuery : IRequest<IEnumerable<Advertisement>>
    {
        public string Title { get; init; }
        public Category Category { get; init; }
        public IEnumerable<AttributeC> Attributes { get; init; }
        
        public class Handler : IRequestHandler<SearchAdvertistementQuery, IEnumerable<Advertisement>>
        {
            private readonly IRepository<Advertisement> _repository;

            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<Advertisement>> Handle(SearchAdvertistementQuery query, CancellationToken cancellationToken)
            {
                List<Advertisement> adverts = await _repository.GetAllAsync();
                IEnumerable<Advertisement> searchResults;
                //only name
                if (query.Title != null && query.Category == null)
                {
                    searchResults = adverts.Where(x => x.Title.Contains(query.Title));
                }
                //only Category
                else if (query.Title == null && query.Category != null)
                {
                    searchResults = adverts.Where(x => x.Categories.Contains(query.Category));
                    
                    if (query.Attributes != null)
                    {
                        foreach (AttributeC att in query.Attributes)
                        {
                            searchResults = adverts.Where(x => x.SameAttributeValue(att));
                        }
                    }
                }
                //Category with name
                else
                {
                    searchResults = adverts
                        .Where(x => x.Title.Contains(query.Title))
                        .Where(x => x.Categories.Contains(query.Category));
                    
                    if (query.Attributes != null)
                    {
                        foreach (AttributeC att in query.Attributes)
                        {
                            searchResults = adverts.Where(x => x.SameAttributeValue(att));
                        }
                    }
                }
                return searchResults;
            }
        }
        
    }
}