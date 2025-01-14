using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.Mediator.Command;
using MultiShop.Order.Application.Features.Mediator.Handler.OrderingHandler;
using MultiShop.Order.Application.Features.Mediator.Queries.OrderingQueries;

namespace MultiShop.Order.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class OrderingsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrderingsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<ActionResult> GetOrderingList()
        {
            var values = await _mediator.Send(new GetOrderingQuery());
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<ActionResult> GetByIdOrdering(int Id)
        {
            var values = await _mediator.Send(new GetOrderingByIdQuery(Id));
            return Ok(values);
        }
        [HttpPost]
        public async Task<ActionResult> CreatedOrdering(CreateOrderingCommand createOrderingCommand)
        {
           await _mediator.Send(createOrderingCommand);
            return Ok("Ordering Başarılya Eklendi");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateOrdering(UpdateOrderingCommand updateOrderingCommand)
        {
            await _mediator.Send(updateOrderingCommand);
            return Ok("Ordering Başarıyla Güncellendi.");
        }
        [HttpDelete]
        public async Task<IActionResult> DeleteOrdering(RemoveOrderingCommand removeOrderingCommand)
        {
            await _mediator.Send(removeOrderingCommand);
            return Ok("Ordering Başarıyla Silindi.");
        }
    }
}
