using System.ComponentModel.DataAnnotations;

namespace STANWEBAPI.Helpers
{
    public static class ValidationContextHelper
    {
        public static bool IsValid(
            this ValidationContext context,
            out IEnumerable<string> validationErrorMessages)
        {
            validationErrorMessages = [];
            var results = new List<ValidationResult>();
            var isValid = Validator.TryValidateObject(
                context.ObjectInstance,
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