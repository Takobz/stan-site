using System.ComponentModel.DataAnnotations;

namespace STANWEBAPI.Helpers
{
    public static class ValidationContextHelper
    {
        public static bool IsValid<T>(
            this ValidationContext context,
            T instance,
            out IEnumerable<string> validationErrorMessages)
        {
            validationErrorMessages = [];
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                instance!,
                context,
                results,
                validateAllProperties: true
            );

            if (!isValid)
            {
                validationErrorMessages = results?.Select(r => r.ErrorMessage ?? string.Empty).ToList() ??
                [
                    "Validation Error Occurred."
                ];
            }

            return isValid;  
        }
    }
}