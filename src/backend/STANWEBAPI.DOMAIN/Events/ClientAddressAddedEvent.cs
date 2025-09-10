using STANWEBAPI.DOMAIN.ValueObjects;

namespace STANWEBAPI.DOMAIN.Events
{
    public class ClientAddressAddedEvent : Event
    {
        public ClientAddressAddedEvent(
            Guid aggregateId,
            string streetNumberAndName,
            string suburb,
            string city,
            string province,
            string country,
            string areaCode
        ) : base(aggregateId, EventTypes.ClientAddressAddedEvent)
        {
            StreetNumberAndName = streetNumberAndName;
            Suburb = suburb;
            City = city;
            Province = province;
            Country = country;
            AreaCode = areaCode;
        }

        public string StreetNumberAndName { get; internal set; }
        public string Suburb { get; internal set; }
        public string City { get; internal set; }
        public string Province { get; internal set; }
        public string Country { get; internal set; }
        public string AreaCode { get; internal set; }
    } 
}