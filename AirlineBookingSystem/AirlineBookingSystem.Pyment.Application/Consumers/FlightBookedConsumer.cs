using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Payment.Application.Commands;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Consumers
{
    public class FlightBookedConsumer : IConsumer<FlightBookedEvent>
    {
        private readonly IMediator _mediator;

        public FlightBookedConsumer(IMediator mediatr)
        {
            _mediator = mediatr;
        }

        public async Task Consume(ConsumeContext<FlightBookedEvent> context)
        {
            var flightBookedEvent = context.Message;

            var command = new CreatePaymentCommand(flightBookedEvent.BookingId, 200.0M);

            await _mediator.Send(command);
        }
    }
}
