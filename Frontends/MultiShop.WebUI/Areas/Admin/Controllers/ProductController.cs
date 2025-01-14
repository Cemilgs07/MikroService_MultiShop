using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using MultiShop.DtoLayer.CatalogDtos.Categories;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;
using System.Text;
using System.Text.Unicode;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Product")]
    public class ProductController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Product");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductDto>>(jsonData);

                return View(values);
            }
            return View();
        }

        [Route("CreateProduct")]
        [HttpGet]
        public async Task<IActionResult> CreateProduct()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Categories");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsonData);
                var createProduct = new CreateProductDto
                {
                    categoryDtos = values
                };
                return View(createProduct);
            }
            return View();
        }

        [Route("CreateProduct")]
        [HttpPost]
        public async Task<IActionResult> CreateProduct(CreateProductDto createProductDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createProductDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }
        [Route("UpdateProduct/{Id}")]
        [HttpGet]
        public async Task<IActionResult> UpdateProduct(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/Product/{Id}");
            var responseCategory = await client.GetAsync("https://localhost:7070/api/Categories");

            if (responseMessage.IsSuccessStatusCode && responseCategory.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var jsoncategories = await responseCategory.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDto>(jsonData);
                var categories = JsonConvert.DeserializeObject<List<ResultCategoryDto>>(jsoncategories);
                values.CategoryDtos = categories;
                return View(values);
            }
            return View();
        }

        [Route("UpdateProduct/{Id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateProduct(UpdateProductDto updateProductDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7070/api/Product", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [Route("DeleteProduct/{Id}")]
        public async Task<IActionResult> DeleteCategory(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürünler";
            @ViewBag.v3 = "Ürün Listesi";
            @ViewBag.v0 = "Ürün İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7070/api/Product/{Id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                return RedirectToAction("Index", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("ResultProductsWithCategory")]
        public async Task<IActionResult> ResultProductsWithCategory()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürün Detay";
            @ViewBag.v3 = "Ürün Detay Listesi";
            @ViewBag.v0 = "Ürün Detay İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7070/api/Product/ResultProductsWithCategory");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultProductsWithCategoryDto>>(jsonData);
                return View(values);
            }
            return View();
        }
    }

}

