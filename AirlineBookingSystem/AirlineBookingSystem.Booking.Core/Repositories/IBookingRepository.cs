namespace AirlineBookingSystem.Booking.Core.Repositories
{
    public interface IBookingRepository
    {
        Task<Entities.Booking> GetBookingById(Guid id);

        Task AddBookingAsync(Entities.Booking booking);
    }
}
