using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebEnpoints.Controllers;
using WebEnpoints.Entities;

namespace WebEnpoints.Tests
{
    public class StudentsControllerTests
    {
        [Fact]
        public async Task Search_ReturnsStudentsMatchingName()
        {
            var options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "StudentDb")
                .Options;

            using (var context = new ApplicationContext(options))
            {
                context.Students.AddRange(new List<Student>
                {
                    new Student { Name = "Alice", Age = 20 },
                    new Student { Name = "Alina", Age = 22 },
                    new Student { Name = "Vladimir", Age = 25 }
                });
                context.SaveChanges();
            }

            using (var context = new ApplicationContext(options))
            {
                var controller = new StudentsController(context);

                var result = await controller.Search("Ali") as ViewResult;

                Assert.NotNull(result);
                var model = Assert.IsAssignableFrom<IEnumerable<Student>>(result.Model);
                Assert.Equal(2, model.Count());
                Assert.All(model, s => Assert.Contains("Ali", s.Name));
            }
        }
    }
}
