using AirlineBookingSystem.Flight.Application.Commands;
using AirlineBookingSystem.Flight.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Flight.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FlightController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FlightController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        [Route("GetFlights")]
        public async Task<IActionResult> GetFlights()
        {
            var flights = await _mediator.Send(new GetAllFlightsQuery());

            return Ok(flights);
        }

        [HttpPost]
        [Route(nameof(AddFlight))]
        public async Task<IActionResult> AddFlight([FromBody] CreateFlightCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(GetFlights), new { id }, command);
        }


        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteFlight([FromRoute] Guid id)
        {
            var flight = await _mediator.Send(new DeleteFlightCommand(id));

            return NoContent();
        }
    }
}
