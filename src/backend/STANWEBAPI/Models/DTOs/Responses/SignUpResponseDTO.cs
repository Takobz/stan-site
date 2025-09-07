namespace STANWEBAPI.Models.DTOs.Responses
{
    public record SignUpResponseDTO(
        Guid UserId,
        string Name,
        string Surname,
        string Email
    );   
}