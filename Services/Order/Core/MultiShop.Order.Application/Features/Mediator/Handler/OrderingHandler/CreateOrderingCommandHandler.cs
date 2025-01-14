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
    public class CreateOrderingCommandHandler : IRequestHandler<CreateOrderingCommand, Unit>
    {
        private readonly IRepository<Ordering> _repository;

        public CreateOrderingCommandHandler(IRepository<Ordering> repository)
        {
            _repository = repository;
        }

        public async Task<Unit> Handle(CreateOrderingCommand request, CancellationToken cancellationToken)
        {
            await _repository.GetCreateAsync(new Ordering
            {
                OrderDate = request.OrderDate,
                TotalPrice = request.TotalPrice,
                UserId = request.UserId,
            });

             return Unit.Value;
        }
    }
}
