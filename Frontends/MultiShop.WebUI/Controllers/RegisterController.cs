using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.IdentityDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
	public class RegisterController : Controller
	{
		private readonly IHttpClientFactory _httpClientFactory;

		public RegisterController(IHttpClientFactory httpClientFactory)
		{
			_httpClientFactory = httpClientFactory;
		}
		public IActionResult Index()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Index(CreateRegisterDto createRegisterDto)
		{
			if (createRegisterDto.ComfirmPassword == createRegisterDto.Password)
			{
				var client = _httpClientFactory.CreateClient();
				var datajson = JsonConvert.SerializeObject(createRegisterDto);
				StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
				var responseMessage = await client.PostAsync("http://localhost:5001/api/Registers", content);
				if (responseMessage.IsSuccessStatusCode)
				{

					return RedirectToAction("Index", "Login");
				}
				return View();
			}
			return View();
		}

	}
}
