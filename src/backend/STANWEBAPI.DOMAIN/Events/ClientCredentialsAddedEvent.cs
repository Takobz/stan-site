namespace STANWEBAPI.DOMAIN.Events
{
    //https://stackoverflow.com/a/73125177/9508771

    public class ClientCredentialsAddedEvent : Event
    {
        public ClientCredentialsAddedEvent(
            Guid aggregateId,
            string eventType,
            string hashedPassword
        ) : base(aggregateId, eventType)
        {
            HashedPassword = hashedPassword;
        }

        public string HashedPassword { get; internal set; }
    }
}