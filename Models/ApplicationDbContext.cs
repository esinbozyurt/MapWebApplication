using Microsoft.EntityFrameworkCore;

namespace WebApplication7.Models  
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        // 'iller' ve 'ilceler' PostgreSQL tabloları için DbSet tanımlamaları
        public DbSet<Il> iller { get; set; }
        public DbSet<Ilce> ilceler { get; set; }
    }
}
