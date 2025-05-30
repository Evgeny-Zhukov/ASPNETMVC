using System.ComponentModel.DataAnnotations;
using WebEnpoints.Validation;

namespace WebEnpoints.Entities
{
    public class Student
    {
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
