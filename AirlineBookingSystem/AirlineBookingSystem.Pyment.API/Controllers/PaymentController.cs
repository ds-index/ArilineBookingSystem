using AirlineBookingSystem.Payment.Application.Commands;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace AirlineBookingSystem.Payment.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentController : ControllerBase
    {

        private readonly IMediator _mediator;

        public PaymentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment([FromBody] CreatePaymentCommand command)
        {
            var id = await _mediator.Send(command);

            return CreatedAtAction(nameof(ProcessPayment), new {id}, command);
        }

        [HttpDelete("refund/{id}")]
        public async Task<IActionResult> RefundPayment([FromRoute] Guid id)
        {
            await _mediator.Send(new DeletePaymentCommand(id));

            return NoContent();
        }
    }
}
