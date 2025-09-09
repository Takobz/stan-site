using STANWEBAPI.DOMAIN.ValueObjects;

namespace STANWEBAPI.DOMAIN.Events
{
    public class ClientCreatedEvent : Event
    {
        public ClientCreatedEvent(
            Guid aggregateId,
            string name,
            string surname,
            string email,
            string phoneNumber,
            string? SAIdNumber,
            string? passportNumber
        ) : base(aggregateId, EventTypes.ClientCreatedEvent)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            SouthAfricanIdentityNumber = SAIdNumber;
            PassportNumber = passportNumber;
        }

        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string? SouthAfricanIdentityNumber { get; internal set; }
        public string? PassportNumber { get; internal set; }

        /*
        * Reminder: Password will be stored in a different table.
        * This is to avoid traversing events to just password.
        */
    }
}
