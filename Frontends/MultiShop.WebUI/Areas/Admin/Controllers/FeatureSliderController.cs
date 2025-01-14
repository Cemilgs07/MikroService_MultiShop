using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.FeatureSlider;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/FeatureSlider")]
    public class FeatureSliderController : Controller
    {
        private IHttpClientFactory _httpClientFactory;

        public FeatureSliderController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Öne Çıkan";
            @ViewBag.v3 = "Öne Çıkan Listesi";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/FeaturesSlider");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultFeatureSliderDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [Route("CreateFeatureSlider")]
        [HttpGet]
        public async Task<IActionResult> CreateFeatureSlider()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Öne Çıkan";
            @ViewBag.v3 = "Öne Çıkan Ekleme";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            return View();
        }
        [Route("CreateFeatureSlider")]
        [HttpPost]
        public async Task<IActionResult> CreateFeatureSlider(CreateFeatureSliderDto createFeatureSliderDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createFeatureSliderDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/FeaturesSlider", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string Id)
        {
            ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Öne Çıkan";
            @ViewBag.v3 = "Öne Çıkan Güncelleme";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/FeaturesSlider/{Id}");

            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateFeatureSliderDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateFeatureSlider/{Id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateFeatureSliderDto updateProductDto)
        {

            ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Öne Çıkan";
            @ViewBag.v3 = "Öne Çıkan Guncelleme";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7070/api/FeaturesSlider", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteFeatureSlider/{Id}")]
        public async Task<IActionResult> DeleteFeatureSlider(string Id)
        {

            ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Öne Çıkan";
            @ViewBag.v3 = "Öne Çıkan Silme";
            @ViewBag.v0 = "Öne Çıkan İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7070/api/FeaturesSlider/{Id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "FeatureSlider", new { area = "Admin" });
            }
            return View();
        }
    }
}
