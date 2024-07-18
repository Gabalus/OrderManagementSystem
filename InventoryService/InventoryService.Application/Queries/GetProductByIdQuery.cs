using InventoryService.Domain.Models;
using MediatR;
using System;

namespace InventoryService.Application.Queries
{
    public class GetProductByIdQuery : IRequest<Product>
    {
        public Guid Id { get; set; }
    }
}