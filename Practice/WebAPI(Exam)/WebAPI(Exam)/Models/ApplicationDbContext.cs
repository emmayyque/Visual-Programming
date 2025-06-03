using Microsoft.EntityFrameworkCore;
using WebAPI_Exam_.Models.Entities;

namespace WebAPI_Exam_.Models
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Bike> Bikes { get; set; }
    }
}
