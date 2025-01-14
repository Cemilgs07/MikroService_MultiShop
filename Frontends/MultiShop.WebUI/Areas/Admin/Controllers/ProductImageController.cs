using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductImageDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductImage")]
    public class ProductImageController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductImageController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [Route("ImageDetails/{Id}")]
        [HttpGet]
        public async Task<IActionResult> ImageDetails(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürün Foto Detayi";
            @ViewBag.v3 = "Ürün Foto Listesi";
            @ViewBag.v0 = "Ürün Foto İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductImage/ProductImageDetails/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductImageDto>(jsonData);
                if (values != null)
                {
                    return View(values);

                }

                return RedirectToAction("CreateImageDetails", "ProductImage", new {area="Admin",Id});

            }
            return View();
        }
        [Route("UpdateImageDetails/{Id}")]
        [HttpPost]
        public async Task<IActionResult> UpdateImageDetails(UpdateProductImageDto updateProductImageDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürün Foto Detayi";
            @ViewBag.v3 = "Ürün Foto Listesi";
            @ViewBag.v0 = "Ürün Foto İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var jsonData = JsonConvert.SerializeObject(updateProductImageDto);
            StringContent content = new StringContent(jsonData, Encoding.UTF8, "application/json");
            var responseMessage = await client.PutAsync($"https://localhost:7070/api/ProductImage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                return View(updateProductImageDto);
            }
            return View();
        }

        [Route("CreateImageDetails/{Id}")]
        [HttpGet]
        public async Task<IActionResult> CreateImageDetails(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürün Foto Ekle";
            @ViewBag.v3 = "Ürün Foto Ekleme";
            @ViewBag.v0 = "Ürün Foto Ekle İşlemleri";
            CreateProductImageDto createProductImageDto = new CreateProductImageDto();
            createProductImageDto.ProductId = Id;
            return View(createProductImageDto);
        }
        [Route("CreateImageDetails")]
        [HttpPost]
        public async Task<IActionResult> CreateImageDetails(CreateProductImageDto createProductImageDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Ürün Foto Ekle";
            @ViewBag.v3 = "Ürün Foto Ekleme";
            @ViewBag.v0 = "Ürün Foto Ekle İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var jsonData= JsonConvert.SerializeObject(createProductImageDto);
            StringContent content = new StringContent(jsonData,Encoding.UTF8,"application/json");
            var responseMessage = await client.PostAsync($"https://localhost:7070/api/ProductImage", content);
            if (responseMessage.IsSuccessStatusCode)
            {
             return   RedirectToAction("ResultProductsWithCategory", "Product",new {area="Admin"});
            }
            return View();
        }
    }
}
