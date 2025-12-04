using AirlineBookingSystem.Booking.Application.Queries;
using AirlineBookingSystem.Booking.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers
{
    public class GetBookingHandler : IRequestHandler<GetBookingQuery, Core.Entities.Booking>
    {
        private readonly IBookingRepository _repo;

        public GetBookingHandler(IBookingRepository repo)
        {
            _repo = repo;
        }

        public async Task<Core.Entities.Booking> Handle(GetBookingQuery request, CancellationToken cancellationToken)
        {
            return await _repo.GetBookingById(request.id);
        }
    }
}
