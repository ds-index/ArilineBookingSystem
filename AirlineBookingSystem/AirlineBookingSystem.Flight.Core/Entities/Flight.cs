using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace AirlineBookingSystem.Flight.Core.Entities
{
    public class Flight
    {
        [BsonId]
        [BsonRepresentation(BsonType.String)]
        public Guid Id { get; set; }

        [BsonElement]
        public string? FlightNumber { get; set; }

        [BsonElement]
        public string? Origin { get;set; }

        [BsonElement]
        public string? Destination { get; set; }

        [BsonElement]
        public DateTime DepartureTime { get; set; }

        [BsonElement]
        public DateTime ArrivalTime { get; set; }
    }
}
