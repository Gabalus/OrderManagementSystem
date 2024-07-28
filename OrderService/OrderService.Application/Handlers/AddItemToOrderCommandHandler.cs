using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Application.Commands;
using OrderService.Domain.Models;
using OrderService.Domain.Repositories;

public class AddItemToOrderCommandHandler : IRequestHandler<AddItemToOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly IInventoryServiceClient _inventoryServiceClient;

    public AddItemToOrderCommandHandler(IOrderRepository orderRepository, IInventoryServiceClient inventoryServiceClient)
    {
        _orderRepository = orderRepository;
        _inventoryServiceClient = inventoryServiceClient;
    }

    public async Task<Guid> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        var product = await _inventoryServiceClient.GetProductByIdAsync(request.ProductId);
        if (product == null || product.Stock < request.Quantity)
        {
            throw new Exception("Product not available in the requested quantity");
        }

        order.Items.Add(new OrderItem
        {
            Id = Guid.NewGuid(),
            ProductId = request.ProductId,
            Quantity = request.Quantity,
            Price = product.Price
        });

        await _orderRepository.UpdateAsync(order);

        return order.Id;
    }
}
