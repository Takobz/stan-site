namespace STANWEBAPI.DOMAIN.Entities
{
    public abstract class AggregateRoot
    {
        public AggregateRoot(Guid id)
        {
            Id = id;
        }

        public Guid Id { get; internal set; }
    }
}