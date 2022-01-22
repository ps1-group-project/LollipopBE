namespace Lollipop.Application.AttributeC.Queries
{
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Application.Repository;
    using Lollipop.Core.Models;
    using Lollipop.Application.DataTransferClasses;
    using MediatR;
    using AutoMapper;
    using Lollipop.Application.AttributeC.Validators;
    using FluentValidation;

    public class GetAttributeByIdQuery : IRequest<AttributeDto>
    {
        public int Id { get; init; }
        public class Handler : IRequestHandler<GetAttributeByIdQuery, AttributeDto>
        {
            private readonly IRepository<AttributeC> _repository;
            private readonly IMapper _mapper;

            public Handler(IRepository<AttributeC> repository)
            {
                _repository = repository;
            }

            public async Task<AttributeDto> Handle(GetAttributeByIdQuery query, CancellationToken cancellationToken)
            {
                await new GetAttributeByIdValidator().ValidateAndThrowAsync(query, cancellationToken);
                AttributeC attribute = await _repository.GetByIdAsync(query.Id);
                return _mapper.Map<AttributeDto>(attribute);
            }
        }
    }
}
