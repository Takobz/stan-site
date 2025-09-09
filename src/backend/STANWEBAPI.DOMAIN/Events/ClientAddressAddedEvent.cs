using STANWEBAPI.DOMAIN.ValueObjects;

namespace STANWEBAPI.DOMAIN.Events
{
    public class ClientAddressAddedEvent : Event
    {
        public ClientAddressAddedEvent(
            Guid aggregateId
        ) : base(aggregateId, EventTypes.ClientAddressAddedEvent)
        { 
            
        }
    } 
}