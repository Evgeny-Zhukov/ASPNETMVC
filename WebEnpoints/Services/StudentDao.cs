using WebEnpoints.Entities;

namespace WebEnpoints.Services
{
    public class StudentDao : IStudentDao
    {
        private readonly List<Student> _students;
        public StudentDao()
        {
            _students = new List<Student>()
            {
                new Student { Id = 1, Name = "Alica", Age = 20, Address = "ул. Ленина, Казань, Россия" },
                new Student { Id = 2, Name = "Vladimir", Age = 21, Address = "ул. Пушкина, Москва, Россия" },
                new Student { Id = 3, Name = "Evgeny", Age = 24, Address = "ул. Мира, Сочи, Россия" },
                new Student { Id = 4, Name = "Alina", Age = 22, Address = "ул. Гоголя, СПб, Россия" },
                new Student { Id = 5, Name = "Diana", Age = 23, Address = "ул. Лесная, Казань, Россия" },
            };
        }
        public List<Student> GetAllStudents() => _students;

        public Student GetById(int id) =>
            _students.FirstOrDefault(s => s.Id == id);

        public List<Student> GetByAge(int min, int max) =>
            _students.Where(s => s.Age >= min && s.Age <= max).ToList();

        public List<Student> Search(string name) =>
            _students.Where(s => s.Name.Contains(name, StringComparison.OrdinalIgnoreCase)).ToList();


        public void Add(Student student)
        { 
            student.Id = _students.Max(s => s.Id) + 1;
            _students.Add(student);
        }
    }
}
