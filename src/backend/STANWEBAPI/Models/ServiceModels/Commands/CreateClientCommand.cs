namespace STANWEBAPI.Models.ServiceModels.Commands
{
    public record CreateClientCommand(
        string Name,
        string Surname,
        string Email,
        string Password,
        string PhoneNumber,
        string PrefferedMethodOfCommunication,
        string ClientType,
        string? SouthAfricanIdentityNumber,
        string? PassportNumber
    );
}