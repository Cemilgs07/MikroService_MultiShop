using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompany;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WepApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCompanyController : ControllerBase
    {
        private readonly ICargoCompanyservice _cargoCompanyservice;

        public CargoCompanyController(ICargoCompanyservice cargoCompanyservice)
        {
            _cargoCompanyservice = cargoCompanyservice;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCompanyservice.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCompany(CreateCargoCompanyDto entity)
        {
            _cargoCompanyservice.TInsert(new CargoComponay()
            {
                CargoCompanyName = entity.CargoCompanyName,
            });
            return Ok("Kargo Şirketi Başarılya Oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult DeleteCompany(int Id)
        {
            _cargoCompanyservice.TDelete(Id);
            return Ok("Kargo Şirketi Başarılya Silindi.");
        }
        [HttpGet("{Id}")]
        public IActionResult GetCargoCompanyById(int Id)
        {
            var values = _cargoCompanyservice.TGetbyId(Id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCompanyDto entity)
        {
            _cargoCompanyservice.TUpdate(new CargoComponay()
            {
                CargoCompanyId = entity.CargoCompanyId,
                CargoCompanyName = entity.CargoCompanyName,
            });
            return Ok("Kargo Şirketi Başarılya Guncellendi.");
        }
    }
}
