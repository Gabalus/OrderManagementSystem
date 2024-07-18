using OrderService.Application.Commands;
using OrderService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;

namespace OrderService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class OrdersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public OrdersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateOrder(CreateOrderCommand command)
        {
            var orderId = await _mediator.Send(command);
            return Ok(orderId);
        }

        [HttpPost("add-item")]
        public async Task<IActionResult> AddItemToOrder(AddItemToOrderCommand command)
        {
            var orderItemId = await _mediator.Send(command);
            return Ok(orderItemId);
        }

        [HttpPost("confirm-payment")]
        public async Task<IActionResult> ConfirmOrderPayment(ConfirmOrderPaymentCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("cancel")]
        public async Task<IActionResult> CancelOrder(CancelOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpPost("deliver")]
        public async Task<IActionResult> DeliverOrder(DeliverOrderCommand command)
        {
            await _mediator.Send(command);
            return NoContent();
        }

        [HttpDelete("{orderId}")]
        public async Task<IActionResult> DeleteOrder(Guid orderId)
        {
            await _mediator.Send(new DeleteOrderCommand { OrderId = orderId });
            return NoContent();
        }

        [HttpGet("{orderId}")]
        public async Task<IActionResult> GetOrderById(Guid orderId)
        {
            var order = await _mediator.Send(new GetOrderByIdQuery { OrderId = orderId });
            if (order == null)
            {
                return NotFound();
            }

            return Ok(order);
        }

        [HttpGet("search")]
        public async Task<IActionResult> SearchOrders([FromQuery] string query)
        {
            var orders = await _mediator.Send(new SearchOrdersQuery { Query = query });
            return Ok(orders);
        }
    }
}
