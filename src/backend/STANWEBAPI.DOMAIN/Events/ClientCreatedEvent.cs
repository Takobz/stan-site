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
            string prefferedMethodOfCommunication,
            string? SAIdNumber,
            string? passportNumber
        ) : base(aggregateId, EventTypes.ClientCreatedEvent)
        {
            Name = name;
            Surname = surname;
            Email = email;
            PhoneNumber = phoneNumber;
            PrefferedMethodOfCommunication = prefferedMethodOfCommunication;
            SouthAfricanIdentityNumber = SAIdNumber;
            PassportNumber = passportNumber;
        }

        public string Name { get; internal set; }
        public string Surname { get; internal set; }
        public string Email { get; internal set; }
        public string PhoneNumber { get; internal set; }
        public string PrefferedMethodOfCommunication { get; internal set; }
        public string? SouthAfricanIdentityNumber { get; internal set; }
        public string? PassportNumber { get; internal set; }
    }
}
