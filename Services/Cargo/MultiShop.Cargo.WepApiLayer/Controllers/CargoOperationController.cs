using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetail;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperation;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WepApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoOperationController : ControllerBase
    {
        private readonly ICargoOperationService _cargo;

        public CargoOperationController(ICargoOperationService cargo)
        {
            _cargo = cargo;
        }


        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargo.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCompany(CreateCargoOpetionDto entity)
        {
            _cargo.TInsert(new CargoOperation()
            {
                Barkod = entity.Barkod,
                OperationDate = entity.OperationDate,
                Description = entity.Description,
            });
            return Ok("Kargo Şirketi Başarılya Oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult DeleteCompany(int Id)
        {
            _cargo.TDelete(Id);
            return Ok("Kargo Şirketi Başarılya Silindi.");
        }
        [HttpGet("{Id}")]
        public IActionResult GetCargoCompanyById(int Id)
        {
            var values = _cargo.TGetbyId(Id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoOperationDto entity)
        {
            _cargo.TUpdate(new CargoOperation()
            {
                Barkod = entity.Barkod,
                CargoOperationId = entity.CargoOperationId,
                Description = entity.Description,
                OperationDate = entity.OperationDate
            });
            return Ok("Kargo Şirketi Başarılya Guncellendi.");
        }
    }
}
