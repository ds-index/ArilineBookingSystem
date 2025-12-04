using AirlineBookingSystem.Payment.Application.Commands;
using AirlineBookingSystem.Payment.Core.Repositories;
using MediatR;

namespace AirlineBookingSystem.Payment.Application.Handlers
{
    public class DeletePaymentCommandHandler : IRequestHandler<DeletePaymentCommand, Guid>
    {
        private readonly IPaymentRepository _repo;

        public DeletePaymentCommandHandler(IPaymentRepository repo)
        {
            _repo = repo;
        }

        public async Task<Guid> Handle(DeletePaymentCommand request, CancellationToken cancellationToken)
        {
            await _repo.RefundPaymentAsync(request.id);

            return request.id;
        }
    }
}
