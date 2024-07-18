using MediatR;
using System;

namespace OrderService.Application.Commands
{
    public class CancelOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
