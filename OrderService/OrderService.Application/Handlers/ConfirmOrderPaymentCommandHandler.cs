﻿using MediatR;
using OrderService.Application.Commands;
using OrderService.Domain.Enums;
using OrderService.Domain.Repositories;
using System;
using System.Threading;
using System.Threading.Tasks;

public class ConfirmOrderPaymentCommandHandler : IRequestHandler<ConfirmOrderPaymentCommand, Unit>
{
    private readonly IOrderRepository _orderRepository;

    public ConfirmOrderPaymentCommandHandler(IOrderRepository orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<Unit> Handle(ConfirmOrderPaymentCommand request, CancellationToken cancellationToken)
    {
        var order = await _orderRepository.GetByIdAsync(request.OrderId);
        if (order == null)
        {
            throw new Exception("Order not found");
        }

        order.Status = OrderStatus.Paid;
        await _orderRepository.UpdateAsync(order);

        return Unit.Value;
    }
}
