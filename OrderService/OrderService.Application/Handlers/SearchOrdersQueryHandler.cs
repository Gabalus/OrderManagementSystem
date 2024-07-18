using MediatR;
using OrderService.Application.Queries;
using OrderService.Domain.Interfaces;
using OrderService.Domain.Models;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace OrderService.Application.Handlers
{
    public class SearchOrdersQueryHandler : IRequestHandler<SearchOrdersQuery, IEnumerable<Order>>
    {
        private readonly IOrderRepository _orderRepository;

        public SearchOrdersQueryHandler(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<Order>> Handle(SearchOrdersQuery request, CancellationToken cancellationToken)
        {
            return await _orderRepository.SearchAsync(request.Query);
        }
    }
}
