using InventoryService.Domain.Interfaces;
using MediatR;
using OrderService.Application.Commands;
using OrderService.Domain.Enums;
using OrderService.Domain.Interfaces;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class DeliverOrderCommandHandler : IRequestHandler<DeliverOrderCommand>
    {
        private readonly IOrderRepository _orderRepository;
        private readonly IProductRepository _productRepository;

        public DeliverOrderCommandHandler(IOrderRepository orderRepository, IProductRepository productRepository)
        {
            _orderRepository = orderRepository;
            _productRepository = productRepository;
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
                var product = await _productRepository.GetByIdAsync(item.ProductId);
                if (product == null || product.Stock < item.Quantity)
                {
                    throw new Exception("Product not available in the requested quantity");
                }

                product.Stock -= item.Quantity;
                await _productRepository.UpdateAsync(product);
            }

            order.Status = OrderStatus.Delivered;
            await _orderRepository.UpdateAsync(order);

            return Unit.Value;
        }
    }
}
