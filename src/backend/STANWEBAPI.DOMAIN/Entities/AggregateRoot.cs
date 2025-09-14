using STANWEBAPI.DOMAIN.Events;

namespace STANWEBAPI.DOMAIN.Entities
{
    /*
        An aggregate should be able to:
        - Have a list of events yet to be committed
        - Apply a list of events to get current state of aggregate.
        - add event to uncommitted events.
    */
    public abstract class AggregateRoot
    {
        public AggregateRoot(Guid id)
        {
            Id = id;
        }

        /// <summary>
        /// Aggregate Id
        /// </summary>
        public Guid Id { get; internal set; }

        /// <summary>
        /// All events that are not yet committed to the event store.
        /// </summary>
        private readonly List<Event> _uncomittedEvents = [];

        /// <summary>
        /// Interface to expose all uncomitted events as readonly.
        /// </summary>
        public IReadOnlyList<Event> UncommittedEvents => _uncomittedEvents.AsReadOnly();

        /// <summary>
        /// Add an event to the uncomitted list.
        /// </summary>
        /// <param name="event">Event we want to be committed.</param>
        public void AddEvent(Event @event)
        {
            _uncomittedEvents.Add(@event);
        }

        /// <summary>
        /// Reconstruct the state of the agregate by applying all events related to the aggregate.
        /// </summary>
        /// <param name="events">List of events related to aggregate, most likey from the event store</param>
        public void LoadFromHistory(IEnumerable<Event> events)
        {
            foreach (var @event in events)
            {
                ApplyEvent(@event);
            }
        }

        /// <summary>
        /// Call this after committing all events to the event store.
        /// </summary>
        public void ClearUncommittedEvents()
        {
            _uncomittedEvents.Clear();
        }

        /// <summary>
        /// Applies an event which will mutate the aggregate or it's dependencies.
        /// </summary>
        /// <param name="event">Event at certain point in time, most likely from the event store</param>
        public abstract void ApplyEvent(Event @event);
    }
}