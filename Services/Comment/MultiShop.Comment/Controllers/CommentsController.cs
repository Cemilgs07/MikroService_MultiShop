using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Context;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CommentsController : ControllerBase
    {
        private readonly CommentContext _commentContext;

        public CommentsController(CommentContext commentContext)
        {
            _commentContext = commentContext;
        }

        [HttpGet]
        public async Task<IActionResult> Comment()
        {
            var values = await _commentContext.UserComments.ToListAsync();
            return Ok(values);
        }

        [HttpPost]
        public async Task<IActionResult> Comment(UserComment userComment)
        {
             _commentContext.UserComments.Add(userComment);
            await _commentContext.SaveChangesAsync();
            return Ok("Yorum Başarıla Eklendi.");
        }
        [HttpPut]
        public async Task<IActionResult> UpdateComment(UserComment userComment)
        {
            _commentContext.UserComments.Update(userComment);
            await _commentContext.SaveChangesAsync();
            return Ok("Yorum Başarıla Güncellendi.");
        }
        [HttpGet("{Id}")]
        public async Task<IActionResult> GetByIdComment(int Id)
        {
            var values= await  _commentContext.UserComments.FindAsync(Id);
            return Ok(values);
        }

        [HttpDelete]
        public async Task<IActionResult> DeleteComment(int Id)
        {
            var values= _commentContext.UserComments.FindAsync(Id);
            _commentContext.Remove(values);
            await _commentContext.SaveChangesAsync();
            return Ok("Yorum Başarıla Silindi.");
        }
        [HttpGet("CommentListProductId/{Id}")]
        public async Task<IActionResult> CommentListProductId(string Id)
        {
            var values = await _commentContext.UserComments.Where(x=>x.ProductId==Id.ToString()).ToListAsync();
            return Ok(values);
        }
    }
}
