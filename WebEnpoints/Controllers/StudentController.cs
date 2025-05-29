using Microsoft.AspNetCore.Mvc;
using WebEnpoints.Models;
using WebEnpoints.Services;

namespace WebEnpoints.Controllers
{
    [Route("student")]
    public class StudentController : Controller
    {
        private readonly IStudentDao _dao;

        public StudentController(IStudentDao dao)
        {
            _dao = dao;
        }

        [HttpGet("")]
        public IActionResult Index()
        {
            return View(_dao.GetAllStudents());
        }

        [HttpGet("byage")]
        public IActionResult ByAge(int minAge, int maxAge)
        {
            var students = _dao.GetByAge(minAge, maxAge);

            return View("Index", students);
        }

        [HttpGet("search")]
        public IActionResult Search(string name)
        {
            var students = _dao.Search(name);

            return View("Index", students);
        }

        [HttpGet("details/{id}")]
        public IActionResult Details(int id)
        {
            var student = _dao.GetById(id);
            if (student == null)
                return NotFound();
            
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

            _dao.Add(student);

            return RedirectToAction("Index");
        }
    }
}
