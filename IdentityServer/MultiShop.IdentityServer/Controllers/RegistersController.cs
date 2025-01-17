using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MultiShop.IdentityServer.Dtos;
using MultiShop.IdentityServer.Models;
using System.Threading.Tasks;
using static IdentityServer4.IdentityServerConstants;

namespace MultiShop.IdentityServer.Controllers
{
    [AllowAnonymous]
    [Route("api/[controller]")]
    [ApiController]
    public class RegistersController : ControllerBase
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public RegistersController(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        [HttpPost]
        public async Task<IActionResult> UserRegister(UserRegististerDto userRegististerDto)
        {
            var values = new ApplicationUser
            {
                UserName = userRegististerDto.UserName,
                Email = userRegististerDto.Email,
                Name=userRegististerDto.UserName,
                SurnName=userRegististerDto.Surname,
            };

            var result= await _userManager.CreateAsync(values,userRegististerDto.Password);
            if (result.Succeeded) 
            {
                return Ok("Kullanıcı Başarıyla Eklendi.");
            }
            else
            {
                return Ok("Bir Hata Oluştu.");
            }
        }
    }
}
