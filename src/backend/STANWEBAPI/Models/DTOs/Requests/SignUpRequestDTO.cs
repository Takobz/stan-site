using System.ComponentModel.DataAnnotations;

namespace STANWEBAPI.Models.DTOs.Requests
{
    public record SignUpRequestDTO(
        [Required(ErrorMessage = "name is a required field")] string Name,
        [Required(ErrorMessage = "surname is a required field")] string Surname,
        [Required(ErrorMessage = "email is a required field")]
        [EmailAddress(ErrorMessage = "email format is not correct")] string Email,
        [Required(ErrorMessage = "password is a required field")] string Password,
        [Required(ErrorMessage = "phone is numer is a required field")] string PhoneNumber,
        string? SouthAfricanIdentityNumber,
        string? PassportNumber
    );
}