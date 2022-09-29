using AnotherGifApp.Models;
using Microsoft.EntityFrameworkCore;
namespace AnotherGifApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<Gif>? Gif { get; set; }
    }
}
