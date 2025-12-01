namespace AirlineBookingSystem.Payment.Core.Repositories
{
    public interface IPaymentRepository
    {
        Task ProcessPaymentAsync(Entities.Payment payment);

        Task RefundPaymentAsync(Guid id);
    }
}
