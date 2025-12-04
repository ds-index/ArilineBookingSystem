using MediatR;

namespace AirlineBookingSystem.Flight.Application.Commands
{
    public record DeleteFlightCommand(Guid id) : IRequest<Guid>;
}
