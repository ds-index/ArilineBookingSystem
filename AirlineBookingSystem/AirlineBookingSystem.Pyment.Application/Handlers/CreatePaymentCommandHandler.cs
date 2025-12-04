using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repo;

        public  CreatePaymentCommandHandler(IPaymentRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CreatePaymentCommand request, CancellationToken cancellationToken)
        {

            var payment = new Core.Entities.Payment
            {
                Id = Guid.NewGuid(),
                BookingId = request.bookingId,
                Amount = request.amount,
                PaymentDate = DateTime.UtcNow,
            };

            await _repo.ProcessPaymentAsync(payment);

            return payment.Id;
        }
    }
}
