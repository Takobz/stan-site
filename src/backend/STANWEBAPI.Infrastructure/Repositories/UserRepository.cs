using Microsoft.Extensions.Options;
using MongoDB.Driver;
using STANWEBAPI.Data.Interfaces;
using STANWEBAPI.Data.MongoDB.DataModels;
using STANWEBAPI.Data.Options;
using STANWEBAPI.DOMAIN.Entities;

namespace STANWEBAPI.Infrastructure.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly IMongoClient _mongoClient;
        private readonly IMongoCollection<EventData> _eventStore;

        public ClientRepository(
            IMongoClient client,
            IOptions<MongoDBOptions> options)
        {
            _mongoClient = client;
            var mongoDatabase = _mongoClient.GetDatabase(
                options.Value.DatabaseName
            );

            _eventStore = mongoDatabase.GetCollection<EventData>(
                options.Value.EventsCollectionName
            );
        }
        

        public async Task<Client> CreateClient(Client client)
        {
            // TODO: get uncommited events on create than add to collection
            //var uncommittedEvents = client.UncommittedEvents();
            throw new NotImplementedException();
        }

        public async Task<Client?> GetClient(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}