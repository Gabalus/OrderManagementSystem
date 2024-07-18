using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class GetStockEntriesByProductIdQueryHandler : IRequestHandler<GetStockEntriesByProductIdQuery, IEnumerable<StockEntry>>
    {
        private readonly IStockEntryRepository _stockEntryRepository;

        public GetStockEntriesByProductIdQueryHandler(IStockEntryRepository stockEntryRepository)
        {
            _stockEntryRepository = stockEntryRepository;
        }

        public async Task<IEnumerable<StockEntry>> Handle(GetStockEntriesByProductIdQuery request, CancellationToken cancellationToken)
        {
            return await _stockEntryRepository.GetByProductIdAsync(request.ProductId);
        }
    }
}
