using JWTService.Models;
using Microsoft.EntityFrameworkCore;

namespace JWTService.DataContext
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options) 
        {
            
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=test;Username=postgres;Password=3117");
        }

        public DbSet<User> Users { get; set; }

        public DbSet<Employee> Employees { get; set; }


    }
}
