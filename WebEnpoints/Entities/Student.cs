using System.Security.Cryptography.X509Certificates;

namespace WebEnpoints.Models
{
    public class Student
    {
        public static List<Student> All {get; set;}

        static Student()
        {
            All = new List<Student>()
            {
                new Student { Id = 1, Name = "Alica", Age = 20 },
                new Student { Id = 2, Name = "Vladimir", Age = 21 },
                new Student { Id = 3, Name = "Evgeny", Age = 24 },
                new Student { Id = 4, Name = "Alina", Age = 22 },
                new Student { Id = 5, Name = "Diana", Age = 23 },
            };
        }

        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public int Age { get; set; }
    }
}
