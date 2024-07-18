using InventoryService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;

namespace InventoryService.Application.Queries
{
    public class GetStockEntriesByProductIdQuery : IRequest<IEnumerable<StockEntry>>
    {
        public Guid ProductId { get; set; }
    }
}
