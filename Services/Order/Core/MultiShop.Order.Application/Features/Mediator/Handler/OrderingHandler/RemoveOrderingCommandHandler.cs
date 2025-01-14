using MediatR;
using MultiShop.Order.Application.Features.Mediator.Command;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.Mediator.Handler.OrderingHandler
{
    public class RemoveOrderingCommandHandler : IRequestHandler<RemoveOrderingCommand>
    {
        private readonly IRepository<Ordering> _repository;

        public RemoveOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(RemoveOrderingCommand request, CancellationToken cancellationToken)
        {
            var values= await _repository.GetByIdAsync(request.Id);
            await _repository.GetDeleteAsync(values);
            return Unit.Value;
        }
    }
}
