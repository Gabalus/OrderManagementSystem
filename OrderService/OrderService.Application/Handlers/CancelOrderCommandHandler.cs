using MediatR;
using OrderService.Application.Commands;
using OrderService.Domain.Enums;
using OrderService.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

public class CancelOrderCommandHandler : IRequestHandler<CancelOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public CancelOrderCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(CancelOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        order.Status = OrderStatus.Cancelled;
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
