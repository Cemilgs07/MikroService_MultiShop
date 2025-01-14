using Microsoft.EntityFrameworkCore;
using MultiShop.Comment.Entites;

namespace MultiShop.Comment.Context
{
    public class CommentContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=localhost,1442;Initial Catalog=MultiShopComment; User=sa; Password=123456Aa*");
        }
        public DbSet<UserComment> UserComments { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserComment>().HasKey(x => x.UserCommentId);
        }
    }
}
