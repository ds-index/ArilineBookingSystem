using MediatR;

namespace AirlineBookingSystem.Payment.Application.Commands
{
    public record DeletePaymentCommand(Guid id) : IRequest<Guid>;
}
