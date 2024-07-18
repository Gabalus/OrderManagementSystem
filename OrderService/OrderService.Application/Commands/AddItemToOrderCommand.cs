using MediatR;
using System;

namespace OrderService.Application.Commands
{
    public class AddItemToOrderCommand : IRequest<Guid>
    {
        public Guid OrderId { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
    }
}
