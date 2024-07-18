using MediatR;
using System;

namespace InventoryService.Application.Commands
{
    public class CreateProductCommand : IRequest<Guid>
    {
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }
    }
}