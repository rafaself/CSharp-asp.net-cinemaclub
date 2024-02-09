using System.ComponentModel.DataAnnotations;

namespace FirstAPI.Validations;

public class EnsureNonZeroAttribute : ValidationAttribute
{
    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        if (value == null || (int)value == 0)
        {
            return new ValidationResult(ErrorMessage);
        }

        return ValidationResult.Success;
    }
}