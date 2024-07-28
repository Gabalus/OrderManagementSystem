using MediatR;
using OrderService.Application.Queries;
using OrderService.Domain.Models;
using OrderService.Domain.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class GetOrderByIdQueryHandler : IRequestHandler<GetOrderByIdQuery, Order>
    {
        private readonly IOrderRepository _orderRepository;

        public GetOrderByIdQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<Order> Handle(GetOrderByIdQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.GetByIdAsync(request.OrderId);
        }
    }
}
