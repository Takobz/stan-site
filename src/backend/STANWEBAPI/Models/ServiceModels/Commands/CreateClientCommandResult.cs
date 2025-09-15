namespace STANWEBAPI.Models.ServiceModels.Commands
{ 
    public record CreateClientCommandResult (
        Guid ClientId,
        string Name,
        string Surname,
        string Email,
        string PhoneNumber
    );
}