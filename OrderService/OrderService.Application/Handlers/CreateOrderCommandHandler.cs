using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using OrderService.Domain.Repositories;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Application.Commands;
using OrderService.Domain.Enums;
using OrderService.Domain.Models;

public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICustomerServiceClient _customerServiceClient;
    private readonly IInventoryServiceClient _inventoryServiceClient;

    public CreateOrderCommandHandler(IOrderRepository orderRepository, ICustomerServiceClient customerServiceClient, IInventoryServiceClient inventoryServiceClient)
    {
        _orderRepository = orderRepository;
        _customerServiceClient = customerServiceClient;
        _inventoryServiceClient = inventoryServiceClient;
    }

    public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
    {
        var customer = await _customerServiceClient.GetCustomerByIdAsync(request.CustomerId);
        if (customer == null)
        {
            throw new Exception("Customer not found");
        }

        var order = new Order
        {
            Id = Guid.NewGuid(),
            CustomerId = request.CustomerId,
            Status = OrderStatus.New
        };

        foreach (var item in request.Items)
        {
            var product = await _inventoryServiceClient.GetProductByIdAsync(item.ProductId);
            if (product == null || product.Stock < item.Quantity)
            {
                throw new Exception("Product not available in the requested quantity");
            }

            order.Items.Add(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = item.ProductId,
                Quantity = item.Quantity,
                Price = product.Price
            });
        }

        await _orderRepository.CreateAsync(order);

        return order.Id;
    }
}
