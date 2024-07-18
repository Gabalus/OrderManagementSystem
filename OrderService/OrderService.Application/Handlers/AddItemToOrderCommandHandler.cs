using MediatR;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using InventoryService.Infrastructure;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;
using OrderService.Application.Commands;

namespace OrderService.Application.Handlers
{
    public class AddItemToOrderCommandHandler : IRequestHandler<AddItemToOrderCommand, Guid>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly InventoryDbContext _inventoryDbContext;

        public AddItemToOrderCommandHandler(IOrderRepository orderRepository, InventoryDbContext inventoryDbContext)
        {
            _orderRepository = orderRepository;
            _inventoryDbContext = inventoryDbContext;
        }

        public async Task<Guid> Handle(AddItemToOrderCommand request, CancellationToken cancellationToken)
        {
            var order = await _orderRepository.GetByIdAsync(request.OrderId);
            if (order == null)
            {
                throw new Exception("Order not found");
            }

            var product = await _inventoryDbContext.Products.FindAsync(request.ProductId);
            if (product == null || product.Stock < request.Quantity)
            {
                throw new Exception("Product not available in the requested quantity");
            }

            order.AddItem(new OrderItem
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Price = product.Price
            });

            product.Stock -= request.Quantity;
            _inventoryDbContext.Products.Update(product);
            await _inventoryDbContext.SaveChangesAsync();

            await _orderRepository.UpdateAsync(order);

            return order.Id;
        }
    }
}
