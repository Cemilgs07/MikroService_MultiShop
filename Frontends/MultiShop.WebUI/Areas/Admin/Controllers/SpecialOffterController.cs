using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.SpecialOftter;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/SpecialOffter")]

    public class SpecialOffterController : Controller
    {

        private readonly IHttpClientFactory _httpClientFactory;

        public SpecialOffterController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("Index")]
        public async Task<IActionResult> Index()
        {

            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "İndirim";
            @ViewBag.v3 = "İndirim Listesi";
            @ViewBag.v0 = "İndirim İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/SpecialOfter");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultSpecialOfterDto>>(jsonData);

                return View(values);
            }
            return View();
        }
        [Route("CreateSpecialOffter")]
        [HttpGet]
        public async Task<IActionResult> CreateSpecialOffter()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "İndirim";
            @ViewBag.v3 = "İndirim Listesi";
            @ViewBag.v0 = "İndirim İşlemleri";

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateSpecialOffter(CreateSpecialOfterDto createSpecialOfter)
        {

            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "İndirim";
            @ViewBag.v3 = "İndirim Listesi";
            @ViewBag.v0 = "İndirim İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createSpecialOfter);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/SpecialOfter", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffter", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateSpecialOftter/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateSpecialOffter(string Id)
        {

            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "İndirim";
            @ViewBag.v3 = "İndirim Listesi";
            @ViewBag.v0 = "İndirim İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/SpecialOfter/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateSpecialOfterDto>(jsonData);
                return View(values);
            }
            return View();
        }

        [Route("UpdateSpecialOftter")]
        [HttpPost]
        public async Task<IActionResult> UpdateSpecialOffter(UpdateSpecialOfterDto updateSpecialOfterDto)
        {
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateSpecialOfterDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7070/api/SpecialOfter", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "SpecialOffter", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteSpecialOftter/{Id}")]
        public async Task<IActionResult> DeleteSpecialOffter(string Id)
        {

            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7070/api/SpecialOfter/{Id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "SpecialOffter", new { area = "Admin" });
            }
            return View();
        }
    }
}
