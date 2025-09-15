using STANWEBAPI.Data.Interfaces;
using STANWEBAPI.DOMAIN.Entities;
using STANWEBAPI.Models.ServiceModels.Commands;

namespace STANWEBAPI.Services
{
    public interface IClientService
    {
        Task<CreateClientCommandResult> CreateClientAsync(CreateClientCommand command);
    }

    public class ClientService : IClientService
    {
        public readonly IClientRepository _clientRepository;
        public readonly ILogger<ClientService> _logger;

        public ClientService(
            IClientRepository clientRepository,
            ILogger<ClientService> logger
        )
        {
            _clientRepository = clientRepository;
            _logger = logger;      
        }

        public async Task<CreateClientCommandResult> CreateClientAsync(CreateClientCommand command)
        {
            var clientId = Guid.NewGuid();
            var client = new Client(
                clientId: clientId,
                clientType: command.ClientType,
                name: command.Name,
                surname: command.Surname,
                email: command.Email,
                phoneNumber: command.PhoneNumber
            );

            

            var createClient = await _clientRepository.CreateClient(client);
            return new CreateClientCommandResult(
                ClientId: createClient.ClientId,
                Name: createClient.Name,
                Surname: createClient.Surname,
                Email: createClient.Email,
                PhoneNumber: createClient.PhoneNumber
            );
        }
    }
}