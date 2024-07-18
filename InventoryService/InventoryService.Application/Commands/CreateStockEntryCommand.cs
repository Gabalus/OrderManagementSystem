using MediatR;
using System;

namespace InventoryService.Application.Commands
{
    public class CreateStockEntryCommand : IRequest<Guid>
    {
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }
    }
}
