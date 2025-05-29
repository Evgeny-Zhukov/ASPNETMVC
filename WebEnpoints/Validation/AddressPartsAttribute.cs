using System.ComponentModel.DataAnnotations;

namespace WebEnpoints.Validation
{
    public class AddressPartsAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            if (value is not string address || string.IsNullOrWhiteSpace(address))
                return new ValidationResult("Адрес не должен быть пустым");

            var parts = address.Split(',', StringSplitOptions.RemoveEmptyEntries | StringSplitOptions.TrimEntries);

            if(parts.Length != 3)
                return new ValidationResult(ErrorMessage ?? "Адрес должен содержать три части, разделенные запятыми");
            
            return ValidationResult.Success;
        }
    }
}
