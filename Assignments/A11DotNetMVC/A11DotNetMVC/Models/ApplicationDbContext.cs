using A11DotNetMVC.Models.Entities;
using Microsoft.EntityFrameworkCore;

namespace A11DotNetMVC.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Department> Departments { get; set; }
    }
}
