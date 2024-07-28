using MediatR;
using OrderService.Application.Commands;
using OrderService.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class DeleteOrderCommandHandler : IRequestHandler<DeleteOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public DeleteOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(DeleteOrderCommand request, CancellationToken cancellationToken)
        {
            await _orderRepository.DeleteAsync(request.OrderId);
            return Unit.Value;
        }
    }
}
