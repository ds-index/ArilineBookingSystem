using AirlineBookingSystem.Flight.Core.Repositories;
using AirlineBookingSystem.Flight.Infra.Data;
using MongoDB.Driver;

namespace AirlineBookingSystem.Flight.Infra.Repositories
{
    public class FlightRepository : IFlightRepository
    {
        private readonly IFlightContext _flightContext;

        public FlightRepository(IFlightContext flightContext)
        {
            _flightContext = flightContext;
        }

        public async Task AddFlightAsync(Core.Entities.Flight flight)
        {
            await _flightContext.Flights.InsertOneAsync(flight);
        }

        public async Task DeleteFlightAsync(Guid id)
        {
            await _flightContext.Flights.DeleteOneAsync(fl => fl.Id == id);
        }

        public async Task<IEnumerable<Core.Entities.Flight>> GetFlightsAsync()
        {
            return await _flightContext.Flights.Find(flight => true).ToListAsync();
        }
    }
}
