using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Order.Application.Features.CQRS.Commands.AdressCommands;
using MultiShop.Order.Application.Features.CQRS.Handlers.AdressHandlers;
using MultiShop.Order.Application.Features.CQRS.Queries.AdressQueries;

namespace MultiShop.Order.WepApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class AdressController : ControllerBase
    {
        private readonly GetAdressQueryHandler _getAdressQueryHandler;
        private readonly GetByIdQueryHandler _getByIdQueryHandler;
        private readonly CreateAdressCommandHandler _createAdressCommandHandler;
        private readonly RemoveAdressCommandHandler _removeAdressCommandHandler;
        private readonly UpdateAdressCommandHandler _updateAdressCommandHandler;

        public AdressController(GetAdressQueryHandler getAdressQueryHandler, GetByIdQueryHandler getByIdQueryHandler, CreateAdressCommandHandler createAdressCommandHandler, RemoveAdressCommandHandler removeAdressCommandHandler, UpdateAdressCommandHandler updateAdressCommandHandler)
        {
            _getAdressQueryHandler = getAdressQueryHandler;
            _getByIdQueryHandler = getByIdQueryHandler;
            _createAdressCommandHandler = createAdressCommandHandler;
            _removeAdressCommandHandler = removeAdressCommandHandler;
            _updateAdressCommandHandler = updateAdressCommandHandler;
        }

        [HttpGet]
        public async Task<IActionResult> AdressList()
        {
            var values = await _getAdressQueryHandler.Handle();
            return Ok(values);
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> AdressGetById(int Id)
        {
            var values = await _getByIdQueryHandler.Handler(new GetAdressByIdQuery(Id));
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> CreateAdress(CreateAdressCommand createAdressCommand)
        {
            await _createAdressCommandHandler.Handle(createAdressCommand);
            return Ok("Addres Başarıyla Kayıt Edildi.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteAdress(int Id)
        {
          await _removeAdressCommandHandler.Handle(new RemoveAdressCommand(Id));
            return Ok("Addres Başarıyla Silindi");
        }

         [HttpPut]
        public async Task<IActionResult> UpdateAdress(UpdateAdressCommand updateAdressCommand)
        {
          await _updateAdressCommandHandler.Handle(updateAdressCommand);
            return Ok("Addres Başarıyla Güncellendi.");

        }
    }
}
