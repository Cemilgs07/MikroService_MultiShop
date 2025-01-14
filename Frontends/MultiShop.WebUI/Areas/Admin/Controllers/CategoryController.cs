using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.Categories;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json.Serialization;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Category")]
    public class CategoryController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CategoryController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Kategori Listesi";
            @ViewBag.v0 = "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpGet]
        [Route("CreateCategory")]

        public async Task<IActionResult> CreateCategory()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Yeni Kategori Ekle";
            @ViewBag.v0 = "Kategori İşlemleri";
            return View();
        }
        [HttpPost]
        [Route("CreateCategory")]
        public async Task<IActionResult> CreateCategory(CreateCategoryDto createCategory)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Yeni Kategori Ekle";
            @ViewBag.v0 = "Kategori İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createCategory);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Categories/CreateCategory", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                //var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject(jsonData);
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }


        [Route("DeleteCategory/{Id}")]

        public async Task<IActionResult> DeleteCategory(DeleteCategoryDto deleteCategoryDtocategoryDto)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7070/api/Categories?id={deleteCategoryDtocategoryDto.Id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsondata= await responseMesage.Content.ReadAsStringAsync();
                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateCategory/{Id}")]
        public async Task<IActionResult> GetUpdateCategory(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Güncelleme Sayfası";
            @ViewBag.v0 = "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/Categories/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCategoryDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateCategory/{Id}")]
        public async Task<IActionResult> UpdateCategory(UpdateCategoryDto updateCategoryDto)
        {

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(updateCategoryDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:7070/api/Categories", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Category", new { area = "Admin" });
            }
            return View();
        }

    }
}
