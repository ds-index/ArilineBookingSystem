namespace AirlineBookingSystem.Flight.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<IEnumerable<Entities.Flight>> GetFlightsAsync();

        Task AddFlightAsync(Entities.Flight flight);

        Task DeleteFlightAsync(Guid id);
    }
}
