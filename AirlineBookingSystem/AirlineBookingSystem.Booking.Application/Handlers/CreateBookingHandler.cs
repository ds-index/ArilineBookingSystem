using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Core.Repositories;
using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Booking.Application.Handlers
{
    public class CreateBookingHandler : IRequestHandler<CreateBookingCommand, Guid>
    {
        private readonly IBookingRepository _repo;
        private readonly IPublishEndpoint _endPoint;

        public CreateBookingHandler(IBookingRepository repo, IPublishEndpoint endpoint)
        {
            _repo = repo;
            _endPoint = endpoint;
        }

        public async Task<Guid> Handle(CreateBookingCommand request, CancellationToken cancellationToken)
        {
            var booking = new Core.Entities.Booking
            {
                Id = Guid.NewGuid(),
                FlightId = request.id,
                PassengerName = request.PassengerName,
                SeatNumber = request.SeatNumber,
                BookingDate = DateTime.UtcNow
            };

            await _repo.AddBookingAsync(booking);

            await _endPoint.Publish(new FlightBookedEvent(
            booking.Id,
            booking.FlightId,
            booking.PassengerName,
            booking.SeatNumber,
            DateTime.UtcNow
            ));

            return booking.Id;
        }
    }
}
