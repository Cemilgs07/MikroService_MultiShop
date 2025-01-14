using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCompany;
using MultiShop.Cargo.DtoLayer.Dtos.CargoDetail;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WepApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoDetailController : ControllerBase
    {
        private readonly ICargoDetailService _cargoDetail;

        public CargoDetailController(ICargoDetailService cargoDetail)
        {
            _cargoDetail = cargoDetail;
        }
        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoDetail.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCompany(CreateCargoDetailDto entity)
        {
            _cargoDetail.TInsert(new CargoDetail()
            {
                Barkod = entity.Barkod,
                CargoCompanyId = entity.CargoCompanyId,
                CargoSenderId = entity.CargoSenderId,
            });
            return Ok("Kargo Şirketi Başarılya Oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult DeleteCompany(int Id)
        {
            _cargoDetail.TDelete(Id);
            return Ok("Kargo Şirketi Başarılya Silindi.");
        }
        [HttpGet("{Id}")]
        public IActionResult GetCargoCompanyById(int Id)
        {
            var values = _cargoDetail.TGetbyId(Id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoDetailDto entity)
        {
            _cargoDetail.TUpdate(new CargoDetail()
            {
                Barkod = entity.Barkod,
                CargoDetailId = entity.CargoDetailId,
                CargoCompanyId = entity.CargoCompanyId,
                CargoSenderId = entity.CargoSenderId,
            });
            return Ok("Kargo Şirketi Başarılya Guncellendi.");
        }
    }
}
