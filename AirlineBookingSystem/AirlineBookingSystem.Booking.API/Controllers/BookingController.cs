using AirlineBookingSystem.Booking.Application.Commands;
using AirlineBookingSystem.Booking.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Booking.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BookingController : ControllerBase
    {
        private readonly IMediator _mediator;

        public BookingController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        [Route("AddBooking")]
        public async Task<IActionResult> AddBooking([FromBody] CreateBookingCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetBookingById), new { id }, command);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetBookingById([FromRoute] Guid id)
        {
            var booking = await _mediator.Send(new GetBookingQuery(id));

            return Ok(booking);
        }
    }
}
