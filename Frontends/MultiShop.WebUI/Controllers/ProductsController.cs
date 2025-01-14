using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CatalogDtos.ProductDtos;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

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
        public async Task<IActionResult> ProductDetail(string Id)
        {
            ViewBag.x = Id;
            return View();
        }
       
       
        [HttpPost]
        public async Task<IActionResult> AddComment(CreateCommentDto createCommentDto)
        {
            createCommentDto.Rating = 3;
           createCommentDto.CommentCreateDate = DateTime.Now;
            createCommentDto.ImageUrl = "/online-shop-website-template/img/user.jpg";
            createCommentDto.Status = true;
            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(createCommentDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7074/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                //var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject(jsonData);
                return RedirectToAction("ProductDetail", "Products", new { Id=createCommentDto.ProductId});
            }
            return View();
        }
    }
}
