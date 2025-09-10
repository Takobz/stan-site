namespace STANWEBAPI.DOMAIN.Entities
{
    public class Client : AggregateRoot
    {
        public Client(
            Guid clientId,
            string clientType,
            string name,
            string surname
        ) : base(clientId)
        {
            ClientId = clientId;
            ClientType = clientType;
            Name = name;
            Surname = surname;
        }

        public Guid ClientId { get; internal set; }
        public string ClientType { get; internal set; }
        public string Name { get; internal set; }
        public string Surname { get; internal set; }
    }
}