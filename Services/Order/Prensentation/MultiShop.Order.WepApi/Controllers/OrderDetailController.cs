using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.OrderDetailCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.OrderDetailHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.OrderDetailQueries;

namespace MultiShop.Order.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderDetailController : ControllerBase
    {
        private readonly GetOrderDetailQueryHandler _getOrderDetailQueryHandler;
        private readonly GetByIdOrderDetailQueryHandler _getByIdOrderDetailQueryHandler;
        private readonly UpdateOrderDetailCommandHandler _updateOrderDetailCommandHandler;
        private readonly CreateOrderDetailCommandHandler _createOrderDetailCommandHandler;
        private readonly RemoveOrderDetailCommandHandler _removeOrderDetailCommandHandler;

        public OrderDetailController(GetOrderDetailQueryHandler getOrderDetailQueryHandler, GetByIdOrderDetailQueryHandler getByIdOrderDetailQueryHandler, UpdateOrderDetailCommandHandler updateOrderDetailCommandHandler, CreateOrderDetailCommandHandler createOrderDetailCommandHandler, RemoveOrderDetailCommandHandler removeOrderDetailCommandHandler)
        {
            _getOrderDetailQueryHandler = getOrderDetailQueryHandler;
            _getByIdOrderDetailQueryHandler = getByIdOrderDetailQueryHandler;
            _updateOrderDetailCommandHandler = updateOrderDetailCommandHandler;
            _createOrderDetailCommandHandler = createOrderDetailCommandHandler;
            _removeOrderDetailCommandHandler = removeOrderDetailCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderDetailsList()
        {
            var values = await _getOrderDetailQueryHandler.handle();
            return Ok(values);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdOrderDetail(int Id)
        {
            var values = await _getByIdOrderDetailQueryHandler.Handle(new GetOrderDeatilsByIdQuery(Id));
            return Ok(values);
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrderDetail(int Id)
        {
             await _removeOrderDetailCommandHandler.Handle(new GetOrderDeatilsByIdQuery(Id));
            return Ok("Order Detail Başarıyla Silindi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateOrderDetail(UpdateOrderDetailCommand updateOrderDetailCommand)
        {
            await _updateOrderDetailCommandHandler.handle(updateOrderDetailCommand);
            return Ok("Order Detail Başarıyla Güncellendi.");
        }
        [HttpPost]
        public async Task<IActionResult> CreateOrderDetail(CreateOrderDetailCommand createOrderDetailCommand)
        {
            await _createOrderDetailCommandHandler.Handle(createOrderDetailCommand);
            return Ok("Order Detail Başarıyla Eklendi.");
        }
    }
}
