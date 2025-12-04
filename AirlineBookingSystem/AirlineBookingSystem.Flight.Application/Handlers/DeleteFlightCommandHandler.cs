using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Flight.Application.Handlers
{
    public class DeleteFlightCommandHandler : IRequestHandler<DeleteFlightCommand, Guid>
    {
        private readonly IFlightRepository _repo;

        public DeleteFlightCommandHandler(IFlightRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(DeleteFlightCommand request, CancellationToken cancellationToken)
        {
            await _repo.DeleteFlightAsync(request.id);

            return request.id;
        }
    }
}
