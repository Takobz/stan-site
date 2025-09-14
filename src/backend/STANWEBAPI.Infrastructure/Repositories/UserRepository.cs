using Microsoft.Extensions.Options;
using MongoDB.Driver;
using STANWEBAPI.Data.Interfaces;
using STANWEBAPI.Data.MongoDB.DataModels;
using STANWEBAPI.Data.Options;
using STANWEBAPI.DOMAIN.Entities;
using STANWEBAPI.DOMAIN.ValueObjects;
using STANWEBAPI.Infrastructure.Mappers.DataMappers;

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
            var aggregateId = client.Id;
            var uncommittedEvents = client.UncommittedEvents ?? [];
            var uncommittedEventsDataModel = uncommittedEvents.Select(@event =>
            {
                /*
                This piece of logic can be used by all Entities.
                so we can have a central place for mapping events :) 
                */
                if (@event.EventType == EventTypes.ClientCreatedEvent)
                {
                    return ((DOMAIN.Events.ClientCreatedEvent)@event).ClientCreatedEventToDataEvent();
                }
                else
                {
                    throw new NotImplementedException($"Unknown EventType or Not Implemented yet: {@event.EventType}");
                }
            });

            await _eventStore.InsertManyAsync([]);
            client.ClearUncommittedEvents();
            return client;
        }

        // public async Task<Client?> GetClient(Guid id)
        // {
        //     throw new NotImplementedException();
        // }
    }
}