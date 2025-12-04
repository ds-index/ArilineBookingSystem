using AirlineBookingSystem.Booking.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Booking.Infra.Repositories
{
    public class BookingRepository : IBookingRepository
    {
        private readonly IDbConnection _dbConnection;

        public BookingRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task AddBookingAsync(Core.Entities.Booking booking)
        {
            const string sql = @"
                INSERT INTO Bookings(Id, FlightId, PassengerName, SeatNumber, BookingDate)
                Values(@Id, @FlightId, @PassengerName, @SeatNumber, @BookingDate)
            ";

            await _dbConnection.ExecuteAsync(sql, booking);
        }

        public async Task<Core.Entities.Booking> GetBookingById(Guid id)
        {
            const string sql = @"
                SELECT * FROM Bookings 
                WHERE Id = @Id
            ";

            return await _dbConnection.QuerySingleAsync<Core.Entities.Booking>(sql, new {Id = id});
        }
    }
}
