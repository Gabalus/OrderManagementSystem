using MediatR;
using OrderService.Application.Commands;
using OrderService.Application.Interfaces;
using OrderService.Domain.Enums;
using OrderService.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

public class DeliverOrderCommandHandler : IRequestHandler<DeliverOrderCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IInventoryServiceClient _inventoryServiceClient;

    public DeliverOrderCommandHandler(IOrderRepository orderRepository, IInventoryServiceClient inventoryServiceClient)
    {
        _orderRepository = orderRepository;
        _inventoryServiceClient = inventoryServiceClient;
    }

    public async Task<Unit> Handle(DeliverOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        foreach (var item in order.Items)
        {
            var product = await _inventoryServiceClient.GetProductByIdAsync(item.ProductId);
            if (product == null || product.Stock < item.Quantity)
            {
                throw new Exception("Insufficient stock to deliver the order");
            }

            // Update stock accordingly
        }

        order.Status = OrderStatus.Delivered;
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
