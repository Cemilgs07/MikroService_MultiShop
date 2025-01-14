using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using MultiShop.DtoLayer.CommentDtos;

namespace MultiShop.WebUI.ViewComponents.ProductDetailViewComponents
{
    public class _CommentCreate:ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(string Id)
        {
           CreateCommentDto dto = new CreateCommentDto()
           {
               ProductId = Id,

           };

            return View(dto);
        }
    }
}
