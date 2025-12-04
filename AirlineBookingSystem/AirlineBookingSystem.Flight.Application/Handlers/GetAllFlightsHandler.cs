using AirlineBookingSystem.Flight.Application.Queries;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public class GetAllFlightsHandler : IRequestHandler<GetAllFlightsQuery, IEnumerable<Core.Entities.Flight>>
    {
        private readonly IFlightRepository _repo;

        public GetAllFlightsHandler(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task
            <IEnumerable<Core.Entities.Flight>> 
            Handle(GetAllFlightsQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetFlightsAsync();
        }
    }
}
