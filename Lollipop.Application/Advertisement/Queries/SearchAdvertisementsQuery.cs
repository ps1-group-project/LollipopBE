using System.Linq;

namespace Lollipop.Application.Advertisement.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    public class SearchAdvertisementsQuery : IRequest<IEnumerable<Advertisement>>
    {
        public string Title { get; init; }
        public int CategoryId { get; init; }
        public IEnumerable<AttributeC> Attributes { get; init; }
        
        public class Handler : IRequestHandler<SearchAdvertisementsQuery, IEnumerable<Advertisement>>
        {
            private readonly IRepository<Advertisement> _AdvRepository;
            private readonly IRepository<Category> _CatRepository;

            public Handler(IRepository<Advertisement> AdvRepository, IRepository<Category> CatRepository)
            {
                _AdvRepository = AdvRepository;
                _CatRepository = CatRepository;
            }

            public async Task<IEnumerable<Advertisement>> Handle(SearchAdvertisementsQuery query, CancellationToken cancellationToken)
            {
                List<Advertisement> adverts = await _AdvRepository.GetAllAsync();
                IEnumerable<Advertisement> searchResults;
                Category cat = await _CatRepository.GetByIdAsync(query.CategoryId);
                //only name
                if (query.Title != null && cat == null)
                {
                    searchResults = adverts.Where(x => x.Title.Contains(query.Title));
                }
                //only Category
                else if (query.Title == null && cat != null)
                {
                    searchResults = adverts.Where(x => x.Categories.Contains(cat));
                    
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
                        .Where(x => x.Categories.Contains(cat));
                    
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