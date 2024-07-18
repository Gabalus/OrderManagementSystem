using MediatR;
using System;

namespace OrderService.Application.Commands
{
    public class DeliverOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
