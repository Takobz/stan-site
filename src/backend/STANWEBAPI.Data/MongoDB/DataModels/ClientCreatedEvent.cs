using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace STANWEBAPI.Data.MongoDB.DataModels
{
#pragma warning disable CS8618

    /*
    Avoiding using constructors/method that set these properties.
    Might cause overhead when mapping these objects from database.
    Better to keep them close to the database structure as possible
    No business logic just dump classes that hold data.
    */
    public class ClientCreatedEvent : EventData
    {
        [BsonElement("name")]
        public string Name { get; set; }

        [BsonElement("surname")]
        public string Surname { get; set; }

        [BsonElement("email")]
        public string Email { get; set; }

        [BsonElement("phone_number")]
        public string PhoneNumber { get; set; }

        [BsonElement("preffered_method_of_communication")]
        public string PrefferedMethodOfCommunication { get; set; }

        [BsonElement("south_african_identity_number")]
        public string? SouthAfricanIdentityNumber { get; set; }

        [BsonElement("passport_number")]
        public string? PassportNumber { get; set; }
    }
    
#pragma warning restore CS8618
}