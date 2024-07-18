using MediatR;
using OrderService.Domain.Enums;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace OrderService.Application.Commands
{
    public class UpdateOrderCommand : IRequest
    {
        public Guid Id { get; set; }
        public OrderStatus Status { get; set; }
    }

    public class UpdateOrderCommandHandler : IRequestHandler<UpdateOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;

        public UpdateOrderCommandHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Unit> Handle(UpdateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.Id);
 /*           if (order == null)
            {
                throw new NotFoundException(nameof(Order), request.Id);
            }*/

            order.Status = request.Status;
            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
