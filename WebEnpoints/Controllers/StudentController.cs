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

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var student = Student.All.FirstOrDefault(s => s.Id == id);
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        [HttpGet("create")]
        public IActionResult Create() 
        {
            return View();
        }

        [HttpPost("create")]
        public IActionResult Create(Student student)
        {
            if(!ModelState.IsValid)
                return View(student);

            student.Id = Student.All.Max(s => s.Id) + 1;
            Student.All.Add(student);

            return RedirectToAction("Index");
        }
    }
}
