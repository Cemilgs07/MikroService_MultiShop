using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDetailDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/ProductDetail")]
    public class ProductDetailController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductDetailController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
       
        [HttpGet]
        [Route("CreateProductDetail/{Id}")]

        public async Task<IActionResult> CreateProductDetail(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Yeni Kategori Ekle";
            @ViewBag.v0 = "Kategori İşlemleri";
            CreateProductDetailDto createProductDetailDto = new CreateProductDetailDto();
            createProductDetailDto.ProductId = Id;
            return View(createProductDetailDto);
        }
        [HttpPost]
        [Route("CreateProductDetail")]
        public async Task<IActionResult> CreateProductDetail(CreateProductDetailDto createProductDetailDto)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Yeni Kategori Ekle";
            @ViewBag.v0 = "Kategori İşlemleri";
            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createProductDetailDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/ProductDetail", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                //var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject(jsonData);
                return RedirectToAction("ResultProductsWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateProductDetail/{Id}")]
        public async Task<IActionResult> UpdateProductDetail(string Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Kategoriler";
            @ViewBag.v3 = "Güncelleme Sayfası";
            @ViewBag.v0 = "Kategori İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7070/api/ProductDetail/GetUpdateProductIdDetail/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateProductDetailDto>(jsonData);
                if (values == null)
                {
                    return RedirectToAction("CreateProductDetail", "ProductDetail", new { area = "Admin", Id });
                }
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateProductDetail")]
        public async Task<IActionResult> UpdateProductDetail(UpdateProductDetailDto updateProductDetailDto)
        {

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(updateProductDetailDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:7070/api/ProductDetail/", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("ResultProductsWithCategory", "Product", new { area = "Admin" });
            }
            return View();
        }
    }
}
