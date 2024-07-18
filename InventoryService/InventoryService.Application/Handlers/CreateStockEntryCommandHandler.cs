using InventoryService.Application.Commands;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class CreateStockEntryCommandHandler : IRequestHandler<CreateStockEntryCommand, Guid>
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public CreateStockEntryCommandHandler(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task<Guid> Handle(CreateStockEntryCommand request, CancellationToken cancellationToken)
        {
            var stockEntry = new StockEntry
            {
                Id = Guid.NewGuid(),
                ProductId = request.ProductId,
                Quantity = request.Quantity,
                Date = request.Date
            };

            await _stockEntryRepository.CreateAsync(stockEntry);

            return stockEntry.Id;
        }
    }
}
