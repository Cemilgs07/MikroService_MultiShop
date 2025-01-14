using Microsoft.AspNetCore.Mvc;

namespace MultiShop.WebUI.ViewComponents.ConcatViewComponents
{
    public class _ContactDetailPartialComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
