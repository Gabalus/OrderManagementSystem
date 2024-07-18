using InventoryService.Domain.Models;
using MediatR;
using System.Collections.Generic;

namespace InventoryService.Application.Queries
{
    public class SearchProductsQuery : IRequest<IEnumerable<Product>>
    {
        public string Query { get; set; }
    }
}