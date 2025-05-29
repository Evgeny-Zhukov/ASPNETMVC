using System.ComponentModel.DataAnnotations;
using WebEnpoints.Validation;

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

        [Required]
        [StringLength(100, MinimumLength = 3, ErrorMessage = "Имя должно содержать минимум 3 символа")]
        [RegularExpression(@"^[А-Яа-яA-Za-z]+$", ErrorMessage = "Имя должно содержать только буквы")]
        public string Name { get; set; } = string.Empty;

        [Range(18, 120, ErrorMessage = "Возраст должен быть от 18 до 120 лет")]
        public int? Age { get; set; }

        [AddressParts(ErrorMessage = "Адрес должен содержать три части, разделенные запятыми")]
        public string Address { get; set; } = "";
    }
}
