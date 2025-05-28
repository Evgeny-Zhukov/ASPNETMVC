using Microsoft.AspNetCore.Mvc;
using WebEnpoints.Models;

namespace WebEnpoints.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        [HttpGet("")]
        public IActionResult Index()
        {
            return View(Student.All);
        }

        [HttpGet("byage")]
        public IActionResult ByAge(int minAge, int maxAge)
        {
            var filtred = Student.All
                .Where(s => s.Age >= minAge && s.Age <= maxAge)
                .ToList();

            return View("Index", filtred);
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var filtred = Student.All
                .Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase))
                .ToList();

            return View("Index", filtred);
        }
    }
}
