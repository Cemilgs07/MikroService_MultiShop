using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using Newtonsoft.Json;

namespace MultiShop.WebUI.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ProductsController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet("Products/{Id}")]
        public async Task<IActionResult> Index(string Id)
        {
            ViewBag.Id = Id;
            return View();

        }
        public IActionResult ProductDetail(string Id)
        {
            ViewBag.x = Id;
            return View();
        }

    }
}
