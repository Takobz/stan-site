using STANWEBAPI.DOMAIN.Events;
using STANWEBAPI.DOMAIN.ValueObjects;

namespace STANWEBAPI.DOMAIN.Entities
{
    public class Client : AggregateRoot
    {
        public Client(
            Guid clientId,
            string clientType,
            string name,
            string surname,
            string email,
            string phoneNumber
        ) : base(clientId)
        {
            ClientId = clientId;
            ClientType = clientType;
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
        }

#pragma warning disable CS8618

        /*
        This constructor is for reconstructing the entity from events
        Usage: new Client(userId).LoadFromHistory([...])
        */
        public Client(Guid clientId) : base(clientId) { }
        
#pragma warning restore CS8618

        public Guid ClientId { get; internal set; }
        public string ClientType { get; internal set; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }

        public override void ApplyEvent(Event @event)
        {
            // Apply Events that only have Client entity data.
            if (@event.EventType == EventTypes.ClientCreatedEvent)
            {
                var clientCreatedEvent = (ClientCreatedEvent)@event;
                Name = clientCreatedEvent.Name;
                Surname = clientCreatedEvent.Surname;
                Email = clientCreatedEvent.Email;
                PhoneNumber = clientCreatedEvent.PhoneNumber;
            }
        }
    }
}