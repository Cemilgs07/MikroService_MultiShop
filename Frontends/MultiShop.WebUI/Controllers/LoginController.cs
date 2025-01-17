using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using MultiShop.WebUI.Models;
using MultiShop.WebUI.Services;
using MultiShop.WebUI.Services.Interface;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Json;

namespace MultiShop.WebUI.Controllers
{
	public class LoginController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;
		private readonly ILoginServices _loginServices;
		private readonly IIdentityService _ıdentityService;
		public LoginController(IHttpClientFactory httpClientFactory, ILoginServices loginServices, IIdentityService ıdentityService)
		{
			_httpClientFactory = httpClientFactory;
			_loginServices = loginServices;
			_ıdentityService = ıdentityService;
		}

		[HttpGet]
		public async Task<IActionResult> Index()
		{
			return View();
		}

		[HttpPost]
		public async Task<IActionResult> Index(LoginDto loginDto)
		{
			var client = _httpClientFactory.CreateClient();
			var content = new StringContent(JsonSerializer.Serialize(loginDto), Encoding.UTF8, "application/json");
			var response = await client.PostAsync("http://localhost:5001/api/Logins", content);
			if (response.IsSuccessStatusCode)
			{
				var jsonData = await response.Content.ReadAsStringAsync();
				var tokenModel = JsonSerializer.Deserialize<JwtResponseModel>(jsonData, new JsonSerializerOptions
				{
					PropertyNamingPolicy = JsonNamingPolicy.CamelCase,


				});
				if (tokenModel != null)
				{
					JwtSecurityTokenHandler handler = new JwtSecurityTokenHandler();
					var token = handler.ReadJwtToken(tokenModel.Token);
					var claims = token.Claims.ToList();
					if (tokenModel.Token != null)
					{
						claims.Add(new Claim("MultiShopToken", tokenModel.Token));
						var claimIdentity = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme);
						var autprops = new AuthenticationProperties
						{
							ExpiresUtc = tokenModel.ExpireDate,
							IsPersistent = true,
						};
						await HttpContext.SignInAsync(JwtBearerDefaults.AuthenticationScheme, new ClaimsPrincipal(claimIdentity), autprops);

						var id = _loginServices.GetUserId;

						return RedirectToAction("Index", "Default");
					}
				}
			}
			return View();
		}
		[HttpGet]
		public async Task<IActionResult> SignIn()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> SignIn(SignInDto signUpDto)
		{
			return View();
		}
	}
}
