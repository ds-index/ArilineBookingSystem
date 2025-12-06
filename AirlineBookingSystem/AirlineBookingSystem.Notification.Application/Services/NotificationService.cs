using AirlineBookingSystem.BuildingBlocks.Contracts.EventBus.Messages;
using MassTransit;

namespace AirlineBookingSystem.Notification.Application.Services
{
    public class NotificationService
    {
        private readonly IPublishEndpoint _publishEndpoint;

        public NotificationService(IPublishEndpoint publishEndpoint)
        {
            _publishEndpoint = publishEndpoint;
        }

        public async Task SendNotificationAsync(Core.Entities.Notification notification)
        {
            Console.WriteLine("Notification sent successful!");

            var notificationEvent = new NotificationEvent
                (notification.Recipient!, notification.Message!, notification.Type!);

            await _publishEndpoint.Publish(notificationEvent);
        }
    }
}
