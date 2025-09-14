namespace STANWEBAPI.Data.Options
{
    public class MongoDBOptions
    {
        public const string SectionName = "MongoDBOptions";

        public string ConnectionString { get; set; } = string.Empty;
        public string DatabaseName { get; set; } = string.Empty;
        public string EventsCollectionName { get; set; } = "events";
    }
}