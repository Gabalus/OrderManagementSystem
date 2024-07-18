using MediatR;
using System;

namespace OrderService.Application.Commands
{
    public class DeleteOrderCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
