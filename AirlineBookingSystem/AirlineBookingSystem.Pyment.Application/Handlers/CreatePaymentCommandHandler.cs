using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Core.Repositories;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Handlers
{
    public class CreatePaymentCommandHandler : IRequestHandler<CreatePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repo;
        private readonly IPublishEndpoint _endPoint;

        public  CreatePaymentCommandHandler(IPaymentRepository repo, IPublishEndpoint endpoint)
        {
            _repo = repo;
            _endPoint = endpoint;
        }

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

            await _endPoint.Publish(new PaymentProcessedEvent
                (
                payment.Id,
                payment.BookingId,
                payment.Amount,
                payment.PaymentDate
                ));

            return payment.Id;
        }
    }
}
