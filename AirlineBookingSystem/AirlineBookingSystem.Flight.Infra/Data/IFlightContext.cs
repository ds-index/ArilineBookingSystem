using AirlineBookingSystem.Flight.Core.Entities;
using MongoDB.Driver;

namespace AirlineBookingSystem.Flight.Infra.Data
{
    public interface IFlightContext
    {
        IMongoCollection<Core.Entities.Flight> Flights { get; } 
    }
}
