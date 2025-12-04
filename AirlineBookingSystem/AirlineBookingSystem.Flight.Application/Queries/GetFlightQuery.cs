using MediatR;

namespace AirlineBookingSystem.Flight.Application.Queries
{
    public record GetAllFlightsQuery() : IRequest<IEnumerable<Core.Entities.Flight>>;
}
