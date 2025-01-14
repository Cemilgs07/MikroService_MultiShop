using Microsoft.AspNetCore.Mvc;
using MultiShop.Catalog.Dtos.ContactDto;
using Newtonsoft.Json;
using System.Text;

namespace MultiShop.WebUI.Controllers
{
    public class ContactController : Controller
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactController(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {

            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(CreateContactDto contactDto)
        {
            contactDto.IsRead = true;
            contactDto.SendDate = DateTime.Now;
          
            var client = _httpClientFactory.CreateClient();
            var datajson = JsonConvert.SerializeObject(contactDto);
            StringContent content = new StringContent(datajson, Encoding.UTF8, "application/json");
            var responseMessage = await client.PostAsync("https://localhost:7070/api/Contacts", content);
            if (responseMessage.IsSuccessStatusCode)
            {
                //var jsonData = await responseMessage.Content.ReadAsStringAsync();
                //var values = JsonConvert.DeserializeObject(jsonData);
                return RedirectToAction("Index", "Default");
            }
            return View();
        }

    }
}
