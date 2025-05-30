using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using WebEnpoints.Entities;

namespace WebEnpoints.Tests
{
    public static class DbContextHelper
    {
        public static ApplicationContext GetDbContext()
        {
            var configuration = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json")
                .Build();

            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseSqlite(configuration.GetConnectionString("DefaultConnection"))
                .Options;

            return new ApplicationContext(options);
        }
    }
}
