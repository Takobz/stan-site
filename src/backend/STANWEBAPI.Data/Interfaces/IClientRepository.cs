using STANWEBAPI.DOMAIN.Entities;

namespace STANWEBAPI.Data.Interfaces
{
    public interface IClientRepository
    {
        public Task<Client> CreateClient(Client client);
        //public Task<Client?> GetClient(Guid id);
    }
}