namespace AirlineBookingSystem.Notification.Core.Repositories
{
    internal interface INotificationRepository
    {
        Task LogNotificationAsync(Entities.Notification notification);
    }
}
