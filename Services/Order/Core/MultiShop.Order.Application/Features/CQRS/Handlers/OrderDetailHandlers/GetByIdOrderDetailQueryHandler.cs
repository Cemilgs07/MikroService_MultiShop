using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;
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
    public class GetByIdOrderDetailQueryHandler
    {
        private readonly IRepository<OrderDetail> _repository;

        public GetByIdOrderDetailQueryHandler(IRepository<OrderDetail> repository)
        {
            _repository = repository;
        }

        public async Task<GetOrderDetailByIdQueryResult> Handle(GetOrderDeatilsByIdQuery getOrderDeatilsByIdQuery)
        {
            var values = await _repository.GetByIdAsync(getOrderDeatilsByIdQuery.Id);
           return new GetOrderDetailByIdQueryResult
            {
                OrderDetailId=values.OrderDetailId,
                OrderingId=values.OrderingId,
                ProductAmount=values.ProductAmount,
                ProductId=values.ProductId,
                ProductName=values.ProductName,
                ProductPrice=values.ProductPrice,
                ProductTotalPrice = values.ProductTotalPrice
            };
        }
    }
}
