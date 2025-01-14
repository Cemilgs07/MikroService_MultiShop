using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Results.OrderDetailResults;
using MultiShop.Order.Application.Interfaces;
using MultiShop.Order.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers
{
    public class UpdateOrderDetailCommandHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public UpdateOrderDetailCommandHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task handle(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            var values = await _repository.GetByIdAsync(updateOrderDetailCommand.OrderDetailId);
            values.OrderingId = updateOrderDetailCommand.OrderingId;
            values.ProductId = updateOrderDetailCommand.ProductId;
           values.ProductName = updateOrderDetailCommand.ProductName;
            values.ProductAmount = updateOrderDetailCommand.ProductAmount;
            values.ProductTotalPrice = updateOrderDetailCommand.ProductTotalPrice;
           values.ProductPrice = updateOrderDetailCommand.ProductPrice;
            await _repository.GetUpdateAsync(values);
        }
    }
}
