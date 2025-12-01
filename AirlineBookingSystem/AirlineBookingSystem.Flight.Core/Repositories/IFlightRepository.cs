namespace AirlineBookingSystem.Flight.Core.Repositories
{
    public interface IFlightRepository
    {
        Task<IReadOnlyList<Entities.Flight>> GetFlightsAsync();

        Task AddFlightAsync(Entities.Flight flight);

        Task DeleteFlightAsync(Guid id);
    }
}
