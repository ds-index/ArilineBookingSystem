using Microsoft.Extensions.Configuration;
using MongoDB.Driver;

namespace AirlineBookingSystem.Flight.Infra.Data
{
    public class FlightContext : IFlightContext
    {
        public IMongoCollection<Core.Entities.Flight> Flights { get; private set; }

        public FlightContext(IConfiguration configuration)
        {
            var client = new MongoClient(configuration["DatabaseSettings:ConnectionString"]);
            var database = client.GetDatabase(configuration["DatabaseSettings:DatabaseName"]);
            Flights = database.GetCollection<Core.Entities.Flight>(configuration["DatabaseSettings:CollectionName"]);
        }
    }
}
