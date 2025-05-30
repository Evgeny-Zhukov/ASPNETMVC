using Microsoft.EntityFrameworkCore;
using WebEnpoints.Models;

namespace WebEnpoints.Entities
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) 
            : base(options) { }

        public DbSet<Student> Students { get; set; }
    }
}
