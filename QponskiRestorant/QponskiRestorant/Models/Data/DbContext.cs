using Microsoft.EntityFrameworkCore;

namespace QponskiRestorant.Models
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Items> Items { get; set; }
    }
}
