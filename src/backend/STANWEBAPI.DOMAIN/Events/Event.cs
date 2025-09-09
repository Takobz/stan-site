namespace STANWEBAPI.DOMAIN.Events
{
    public abstract class Event
    {
        /// <summary>
        /// Use for creation of new event
        /// </summary>
        public Event(Guid aggregateId, string eventType)
        {
            AggregateId = aggregateId;
            EventType = eventType;
            EventId = Guid.NewGuid();
            EventTimeStamp = DateTimeOffset.UtcNow;
        }

        /// <summary>
        /// Use for reconstructing the event. Example mapping event from event data store.
        /// </summary>
        public Event(
            Guid aggregateId,
            Guid eventId,
            string eventType,
            DateTimeOffset eventTimeStamp
        )
        {
            AggregateId = aggregateId;
            EventId = eventId;
            EventType = eventType;
            EventTimeStamp = eventTimeStamp;
        }

        public Guid EventId { get; internal set; }
        public Guid AggregateId { get; internal set; }
        public string EventType { get; internal set; }
        public DateTimeOffset EventTimeStamp { get; internal set; }
    }
}