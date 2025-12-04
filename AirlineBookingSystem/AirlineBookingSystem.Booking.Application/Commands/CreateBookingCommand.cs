using MediatR;

namespace AirlineBookingSystem.Booking.Application.Commands
{
    public record CreateBookingCommand(Guid id, string PassengerName, string SeatNumber): IRequest<Guid>;
}
