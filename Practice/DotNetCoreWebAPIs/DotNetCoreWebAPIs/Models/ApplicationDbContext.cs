using DotNetCoreWebAPIs.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace DotNetCoreWebAPIs.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products { get; set; }
    }
}
