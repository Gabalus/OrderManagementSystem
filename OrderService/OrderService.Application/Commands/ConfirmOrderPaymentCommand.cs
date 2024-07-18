using MediatR;
using System;

namespace OrderService.Application.Commands
{
    public class ConfirmOrderPaymentCommand : IRequest
    {
        public Guid OrderId { get; set; }
    }
}
