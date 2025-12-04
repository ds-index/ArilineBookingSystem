using MediatR;

namespace AirlineBookingSystem.Booking.Application.Queries
{
    public record GetBookingQuery(Guid id) : IRequest<Core.Entities.Booking>;
}
