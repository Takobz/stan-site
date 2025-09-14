namespace STANWEBAPI.Infrastructure.Mappers.DataMappers
{
    public static class ClientDomainEventsToDataEvents
    {
        public static Data.MongoDB.DataModels.ClientCreatedEvent ClientCreatedEventToDataEvent(
            this DOMAIN.Events.ClientCreatedEvent @event
        )
        {
            return new Data.MongoDB.DataModels.ClientCreatedEvent
            {
                EventId = @event.EventId,
                AggregateId = @event.AggregateId,
                Name = @event.Name,
                Surname = @event.Surname,
                Email = @event.Email,
                PhoneNumber = @event.PhoneNumber,
                PrefferedMethodOfCommunication = @event.PrefferedMethodOfCommunication,
                SouthAfricanIdentityNumber = @event.SouthAfricanIdentityNumber,
                PassportNumber = @event.PassportNumber
            };
        }
    }
}