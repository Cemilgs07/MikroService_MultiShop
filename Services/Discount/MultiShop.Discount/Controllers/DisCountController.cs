using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MultiShop.Discount.Dtos;
using MultiShop.Discount.Services;

namespace MultiShop.Discount.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class DisCountController : ControllerBase
    {
        private readonly IDiscountServices _discountServices;

        public DisCountController(IDiscountServices discountServices)
        {
            _discountServices = discountServices;
        }
        [HttpGet]
        public async Task<IActionResult> CouponDiscountList()
        {
            var values= await _discountServices.GetAllDiscountCouponAsync();
            return Ok(values);
        }
        [HttpGet("{id}")]
        public async Task<IActionResult> GetDiscountCouponById(int id)
        {
            var values = await _discountServices.GetByIdDiscountCouponAsync(id);
            return Ok(values);
        }
        [HttpPost]
        public async Task<IActionResult> CreateDiscountCoupon(CreateDiscountCouponDto createCouponDto)
        {
             await _discountServices.CreateDiscountCouponAsync(createCouponDto);
            return Ok("Coupon Başarılya Oluşturuldu.");
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteDiscountCoupon(int id)
        {
            await _discountServices.DeleteDiscountCouponAsync(id);
            return Ok("Coupon Başarılya Silindi.");
        }

        [HttpPut]
        public async Task<IActionResult> UpdateDiscountCoupon(UptadeDiscountCouponDto uptadeCouponDto)
        {
            await _discountServices.UpdateDiscountCouponAsync(uptadeCouponDto);
            return Ok("Coupon Başarılya Güncellendi.");
        }

    }
}
