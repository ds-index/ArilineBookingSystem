using AirlineBookingSystem.Notification.Application.Commands;
using AirlineBookingSystem.Notification.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Notification.Application.Handlers
{
    public class CreateNotificationCommandHandler : IRequestHandler<CreateNotificationCommand, Guid>
    {
        private readonly INotificationRepository _repo;

        public CreateNotificationCommandHandler(INotificationRepository repo) => _repo = repo;

        public async Task<Guid> Handle(CreateNotificationCommand request, CancellationToken cancellationToken)
        {
            var notification = new Core.Entities.Notification
            {
                Id = Guid.NewGuid(),
                Message = request.Message,
                Recipient = request.Recipient,
                Type = request.type,
                SentAt = DateTime.UtcNow,
                
            };

            await _repo.LogNotificationAsync(notification);

            return notification.Id;
        }
    }
}
