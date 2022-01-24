namespace Lollipop.Application.AttributeC.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using MediatR;
    using System.Collections.Generic;
    using Lollipop.Application.DataTransferClasses;
    using AutoMapper;

    public class GetAttributesCQuery : IRequest<IEnumerable<AttributeDto>>
    {
        public class Handler : IRequestHandler<GetAttributesCQuery, IEnumerable<AttributeDto>>
        {
            private readonly IRepository<AttributeC> _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<IEnumerable<AttributeDto>> Handle(GetAttributesCQuery query, CancellationToken cancellationToken)
            {
                IEnumerable <AttributeC> attributes = await _repository.GetAllAsync();
                return _mapper.Map <IEnumerable<AttributeDto>> (attributes);
            }
        }
    }
}
