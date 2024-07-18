using MediatR;
using System;

namespace InventoryService.Application.Commands
{
    public class DeleteProductCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
