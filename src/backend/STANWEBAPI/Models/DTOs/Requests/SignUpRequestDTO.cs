using System.ComponentModel.DataAnnotations;

namespace STANWEBAPI.Models.DTOs.Requests
{
    public record SignUpRequestDTO
    {
        [Required(ErrorMessage = "name is a required field")]
        public string Name { get; init; } = string.Empty;

        [Required(ErrorMessage = "surname is a required field")]
        public string Surname { get; init; } = string.Empty;

        [Required(ErrorMessage = "email is a required field")]
        [EmailAddress(ErrorMessage = "email format is not correct")]
        public string Email { get; init; } = string.Empty;

        [Required(ErrorMessage = "password is a required field")]
        public string Password { get; init; } = string.Empty;

        [Required(ErrorMessage = "phone is numer is a required field")]
        public string PhoneNumber  { get; init; } = string.Empty;

        public string? SouthAfricanIdentityNumber { get; init; } = string.Empty;

        public string? PassportNumber { get; init; } = string.Empty;

        public SignUpRequestDTO(
            string name,
            string surname,
            string email,
            string password,
            string phoneNumber,
            string? southAfricanIdentityNumber = null,
            string? passportNumber = null)
        {
            Name = name;
            Surname = surname;
            Email = email;
            Password = password;
            PhoneNumber = phoneNumber;
            SouthAfricanIdentityNumber = southAfricanIdentityNumber ?? string.Empty;
            PassportNumber = passportNumber ?? string.Empty;
        }
    }
}