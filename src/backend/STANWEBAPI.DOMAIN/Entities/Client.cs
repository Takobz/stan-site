namespace STANWEBAPI.DOMAIN.Entities
{
    public class Client : AggregateRoot
    {
        public Client(
            Guid clientId,
            string clientType
        ) : base(clientId)
        {
            ClientId = clientId;
            ClientType = clientType;
        }

        public Guid ClientId { get; internal set; } 
        public string ClientType { get; internal set; }
    }
}