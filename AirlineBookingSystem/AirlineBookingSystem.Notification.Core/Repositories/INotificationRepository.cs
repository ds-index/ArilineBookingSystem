namespace AirlineBookingSystem.Notification.Core.Repositories
{
    public interface INotificationRepository
    {
        Task LogNotificationAsync(Entities.Notification notification);
    }
}
