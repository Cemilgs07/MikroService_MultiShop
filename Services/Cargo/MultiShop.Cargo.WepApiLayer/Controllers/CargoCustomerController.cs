using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Cargo.Bussines.Abstract;
using MultiShop.Cargo.DtoLayer.Dtos.CargoCustomer;
using MultiShop.Cargo.DtoLayer.Dtos.CargoOperation;
using MultiShop.Cargo.EntityLayer.Concrete;

namespace MultiShop.Cargo.WepApiLayer.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CargoCustomerController : ControllerBase
    {
        private readonly ICargoCustomerService _cargoCustomer;

        public CargoCustomerController(ICargoCustomerService cargoCustomer)
        {
            _cargoCustomer = cargoCustomer;
        }

        [HttpGet]
        public IActionResult CargoCompanyList()
        {
            var values = _cargoCustomer.TGetAll();
            return Ok(values);
        }
        [HttpPost]
        public IActionResult CreateCompany(CreateCargoCustomerDto entity)
        {
            _cargoCustomer.TInsert(new CargoCustomer()
            {
                Address = entity.Address,
                City = entity.City,
                District = entity.District,
                Email = entity.Email,
                Name = entity.Name,
                Surname = entity.Surname,
            });
            return Ok("Kargo Şirketi Başarılya Oluşturuldu.");
        }
        [HttpDelete]
        public IActionResult DeleteCompany(int Id)
        {
            _cargoCustomer.TDelete(Id);
            return Ok("Kargo Şirketi Başarılya Silindi.");
        }
        [HttpGet("{Id}")]
        public IActionResult GetCargoCompanyById(int Id)
        {
            var values = _cargoCustomer.TGetbyId(Id);
            return Ok(values);
        }

        [HttpPut]
        public IActionResult UpdateCargoCompany(UpdateCargoCustomerDto entity)
        {
            _cargoCustomer.TUpdate(new CargoCustomer()
            {
                Address = entity.Address,
                CargoCustomerId = entity.CargoCustomerId,
                Surname = entity.Surname,
                Name = entity.Name,
                Email = entity.Email,
                District = entity.District,
                City = entity.City
            });
            return Ok("Kargo Şirketi Başarılya Guncellendi.");
        }
    }
}
