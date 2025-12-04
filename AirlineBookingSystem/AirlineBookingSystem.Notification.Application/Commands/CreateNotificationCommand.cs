using MediatR;

namespace AirlineBookingSystem.Notification.Application.Commands
{
    public record CreateNotificationCommand
        (string Recipient, string Message, string type) :
        IRequest<Guid>;

}
