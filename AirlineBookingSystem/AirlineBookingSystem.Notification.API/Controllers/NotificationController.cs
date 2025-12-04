using AirlineBookingSystem.Notification.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Notification.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NotificationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public NotificationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> SendNotification([FromBody] CreateNotificationCommand command)
        {
            var id = await _mediator.Send(command);

            return Ok("Notification send successful.");
        }
    }
}
