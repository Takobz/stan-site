using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace STANWEBAPI.Data.MongoDB.DataModels
{
    public class EventData
    {
        [BsonId]
        [BsonElement("event_id")]
        [BsonRepresentation(BsonType.ObjectId)]
        public Guid EventId { get; set; }

        [BsonElement("aggregate_id")]
        public Guid AggregateId { get; set; }
    }
}