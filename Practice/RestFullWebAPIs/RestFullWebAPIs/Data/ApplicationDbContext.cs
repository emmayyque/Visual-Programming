using Microsoft.EntityFrameworkCore;
using RestFullWebAPIs.Models.Entities;

namespace RestFullWebAPIs.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base (options)
        {
            
        }

        public DbSet<Student> Students { get; set; }
    }
}
