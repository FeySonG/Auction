namespace Auction.Application.Validation;

public class FutureDateAttribute : ValidationAttribute
{
    protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
    {
        if (value == null || value is not DateTime startTime)
        {
            // Если значение null или не является типом DateTime, возвращаем сообщение об ошибке
            return new ValidationResult(ErrorMessage ?? "The field must be a valid date.");
        }

        if (startTime < DateTime.Now)
        {
            return new ValidationResult(ErrorMessage ?? "The field must be a future date.");
        }

        return ValidationResult.Success;
    }
}
