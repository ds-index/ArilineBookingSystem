using MediatR;

namespace AirlineBookingSystem.Payment.Application.Commands
{
    public record CreatePaymentCommand(Guid bookingId, decimal amount) : IRequest<Guid>;

}
