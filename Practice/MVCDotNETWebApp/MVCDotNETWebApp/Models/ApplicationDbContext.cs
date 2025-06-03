using Microsoft.EntityFrameworkCore;
using MVCDotNETWebApp.Models.Entities;

namespace MVCDotNETWebApp.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Product> Products { get; set; }
    }
}
