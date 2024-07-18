using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces
{
    public interface IStockEntryRepository
    {
        Task<IEnumerable<StockEntry>> GetByProductIdAsync(Guid productId);
        Task CreateAsync(StockEntry stockEntry);
    }
}
