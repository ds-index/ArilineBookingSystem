using AirlineBookingSystem.Notification.Core.Repositories;
using Dapper;
using System.Data;

namespace AirlineBookingSystem.Notification.Infra.Repositories
{
    public class NotificationRepository : INotificationRepository
    {
        private readonly IDbConnection _dbConnection;

        public NotificationRepository(IDbConnection dbConnection)
        {
            _dbConnection = dbConnection;
        }

        public async Task LogNotificationAsync(Core.Entities.Notification notification)
        {
            const string sql = @"
                INSERT INTO Notifications(Id, Recipient, Message, Type, SentAt)
                VALUES(@Id, @Recipient, @Message, @Type, @SentAt)
            ";

            await _dbConnection.ExecuteAsync(sql, notification);
        }
    }
}
