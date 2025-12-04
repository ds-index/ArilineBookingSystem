using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public class CreateFlightCommandHandler : IRequestHandler<CreateFlightCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public CreateFlightCommandHandler(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(CreateFlightCommand request, CancellationToken cancellationToken)
        {
            var flight = new Core.Entities.Flight
            {
                Id = Guid.NewGuid(),
                FlightNumber = request.flightNumber,
                Origin = request.Origin,
                Destination = request.Destination,
                ArrivalTime = request.ArrivalTime,
                DepartureTime = DateTime.UtcNow
            };

            await _repo.AddFlightAsync(flight);

            return flight.Id;
        }
    }
}
