namespace Lollipop.Application.Advertisement.Commands
{
    using Lollipop.Application.Repository;
    using MediatR;
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using System.Threading;
    using System.Threading.Tasks;
    using Lollipop.Core.Models;
    using Lollipop.Application.Advertisement.Validators;
    using FluentValidation;

    public class DeleteAdvertisementCommand : IRequest<int>
    {
        public int Id { get; set; }
        public class Handler : IRequestHandler<DeleteAdvertisementCommand, int>
        {
            private readonly IRepository<Advertisement> _repository;
            public Handler(IRepository<Advertisement> repository)
            {
                _repository = repository;
            }
            public async Task<int> Handle(DeleteAdvertisementCommand request, CancellationToken cancellationToken)
            {
                await new DeleteAdvertisementValidator().ValidateAndThrowAsync(request, cancellationToken);
                Advertisement toDelete = await _repository.GetByIdAsync(request.Id);
                await _repository.DeleteAsync(toDelete);
                return toDelete.Id;
            }
        }
    }
}
