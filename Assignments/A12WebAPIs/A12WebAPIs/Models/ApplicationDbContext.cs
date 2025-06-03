using A12WebAPIs.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace A12WebAPIs.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }
        public DbSet<Department> Departments { get; set; }
    }
}
