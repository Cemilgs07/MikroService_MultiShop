using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.Controllers
{
    public class _UILayoutController : Controller
    {
        public IActionResult _UILayout()
        {
            return View();
        }
    }
}
