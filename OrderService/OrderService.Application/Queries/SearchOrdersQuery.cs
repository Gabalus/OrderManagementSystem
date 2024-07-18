using MediatR;
using OrderService.Domain.Models;
using System.Collections.Generic;

namespace OrderService.Application.Queries
{
    public class SearchOrdersQuery : IRequest<IEnumerable<Order>>
    {
        public string Query { get; set; }
    }
}
