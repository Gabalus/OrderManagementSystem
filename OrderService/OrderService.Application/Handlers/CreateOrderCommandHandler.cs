using MediatR;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using InventoryService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Application.Commands;
using OrderService.Domain.Enums;
using System.Collections.Generic;

namespace OrderService.Application.Handlers
{
    public class CreateOrderCommandHandler : IRequestHandler<CreateOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly InventoryDbContext _inventoryDbContext;

        public CreateOrderCommandHandler(IOrderRepository orderRepository, InventoryDbContext inventoryDbContext)
        {
            _orderRepository = orderRepository;
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<Guid> Handle(CreateOrderCommand request, CancellationToken cancellationToken)
        {
            var order = new Order
            {
                Id = Guid.NewGuid(),
                CustomerId = request.CustomerId,
                Status = OrderStatus.New,
                Items = new List<OrderItem>()
            };

            foreach (var item in request.Items)
            {
                var product = await _inventoryDbContext.Products.FindAsync(item.ProductId);
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

                product.Stock -= item.Quantity;
                _inventoryDbContext.Products.Update(product);
            }

            await _inventoryDbContext.SaveChangesAsync();
            await _orderRepository.CreateAsync(order);

            return order.Id;
        }
    }
}
