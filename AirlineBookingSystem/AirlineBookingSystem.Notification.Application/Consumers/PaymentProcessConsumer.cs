using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using AirlineBookingSystem.Notification.Application.Commands;
using MassTransit;
using MediatR;

namespace AirlineBookingSystem.Notification.Application.Consumers
{
    public class PaymentProcessConsumer : IConsumer<PaymentProcessedEvent>
    {
        private readonly IMediator _mediator;

        public PaymentProcessConsumer(IMediator mediator)
        {
            _mediator = mediator;
        }

        public async Task Consume(ConsumeContext<PaymentProcessedEvent> context)
        {
            var paymentProcessEvent = context.Message;

            var message = 
                $"{paymentProcessEvent.Amount} for Booking ID: {paymentProcessEvent.BookingId} was process successful!";
            var command = new CreateNotificationCommand("someone@example.com", message, "Email");

            await _mediator.Send(command);
        }
    }
}
