using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.AboutDtos;
using MultiShop.DtoLayer.CatalogDtos.Categories;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/About")]
    public class AboutController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public AboutController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/About/GetAbout");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateAboutDto>(jsonData);
                if (values == null)
                {
                    return RedirectToAction("CreateAbout", "About", new { area = "Admin" });
                }

                return View(values);
            }
            return View();
        }

        [Route("CreateAbout")]
        [HttpGet]
        public async Task<IActionResult> CreateAbout()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Hakkımda";
            @ViewBag.v3 = "Hakkımda Listesi";
            @ViewBag.v0 = "Hakkımda İşlemleri";


            return View();
        }

        [Route("CreateAbout")]
        [HttpPost]
        public async Task<IActionResult> CreateAbout(CreateAboutDto createAboutDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Hakkımda";
            @ViewBag.v3 = "Hakkımda Listesi";
            @ViewBag.v0 = "Hakkımda İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var jsondata = JsonConvert.SerializeObject(createAboutDto);
            StringContent content = new StringContent(jsondata, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/About", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "About", new { area = "Admin" });
            }
            return View();
        }
    }
}
