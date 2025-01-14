using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MultiShop.DtoLayer.CommentDtos;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Areas.Admin.Controllers
{
    [AllowAnonymous]
    [Area("Admin")]
    [Route("Admin/Comment")]
    public class CommentController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public CommentController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }
        [Route("Index")]
        public async Task<IActionResult> Index()
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Yorumlar";
            @ViewBag.v3 = "Yorum Listesi";
            @ViewBag.v0 = "Yorum İşlemleri";

            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync("https://localhost:7074/api/Comments");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<List<ResultCommentDto>>(jsonData);
                return View(values);
            }
            return View();
        }
       

        [Route("DeleteComment/{Id}")]

        public async Task<IActionResult> DeleteComment(int Id)
        {
            var client = _httpClientFactory.CreateClient();
            var responseMesage = await client.DeleteAsync($"https://localhost:7074/api/Comments?Id={Id}");
            if (responseMesage.IsSuccessStatusCode)
            {
                var jsondata = await responseMesage.Content.ReadAsStringAsync();
                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }

        [HttpGet]
        [Route("UpdateComment/{Id}")]
        public async Task<IActionResult> UpdateComment(int Id)
        {
            @ViewBag.v1 = "AnaSayfa";
            @ViewBag.v2 = "Yorumlar";
            @ViewBag.v3 = "Yorum Listesi";
            @ViewBag.v0 = "Yorum İşlemleri";


            var client = _httpClientFactory.CreateClient();
            var responseMessage = await client.GetAsync($"https://localhost:7074/api/Comments/{Id}");
            if (responseMessage.IsSuccessStatusCode)
            {
                var jsonData = await responseMessage.Content.ReadAsStringAsync();
                var values = JsonConvert.DeserializeObject<UpdateCommentDto>(jsonData);
                return View(values);
            }
            return View();
        }
        [HttpPost]
        [Route("UpdateComment/{Id}")]
        public async Task<IActionResult> UpdateComment(UpdateCommentDto updateCommentDto)
        {

            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(updateCommentDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");

            var responseMessage = await client.PutAsync($"https://localhost:7074/api/Comments", content);
            if (responseMessage.IsSuccessStatusCode)
            {

                return RedirectToAction("Index", "Comment", new { area = "Admin" });
            }
            return View();
        }
    }
}
