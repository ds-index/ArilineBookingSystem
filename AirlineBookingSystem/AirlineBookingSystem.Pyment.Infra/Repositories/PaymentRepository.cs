using AirlineBookingSystem.Payment.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Payment.Infra.Repositories
{
    public class PaymentRepository : IPaymentRepository
    {
        private readonly IDbConnection _dbConnection;

        public PaymentRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task ProcessPaymentAsync(Core.Entities.Payment payment)
        {
            const string sql = @"
                INSERT INTO Payments(Id, BookingId, Amount, PaymentDate)
                VALUES(@Id, @BookingId, @Amount, @PaymentDate)
            ";

            await _dbConnection.ExecuteAsync(sql, payment);
        }

        public async Task RefundPaymentAsync(Guid id)
        {
            const string sql = @"
                DELETE FROM Payments WHERE Id = @Id
            ";

            await _dbConnection.ExecuteAsync(sql, new { Id = id });
        }
    }
}
