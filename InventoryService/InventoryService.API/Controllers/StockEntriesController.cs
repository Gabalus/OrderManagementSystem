using InventoryService.Application.Commands;
using InventoryService.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class StockEntriesController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StockEntriesController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> CreateStockEntry(CreateStockEntryCommand command)
        {
            var product = await _mediator.Send(new GetProductByIdQuery { Id = command.ProductId });
            if (product == null)
            {
                return BadRequest("Product not found");
            }

            var stockEntryId = await _mediator.Send(command);
            return Ok(stockEntryId);
        }

        [HttpGet("{productId}")]
        public async Task<IActionResult> GetStockEntriesByProductId(Guid productId)
        {
            var stockEntries = await _mediator.Send(new GetStockEntriesByProductIdQuery { ProductId = productId });
            return Ok(stockEntries);
        }
    }
}
