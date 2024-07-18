using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace InventoryService.Infrastructure.Repositories
{
    public class StockEntryRepository : IStockEntryRepository
    {
        private readonly InventoryDbContext _context;

        public StockEntryRepository(InventoryDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<StockEntry>> GetByProductIdAsync(Guid productId)
        {
            return await _context.StockEntries
                .Where(se => se.ProductId == productId)
                .ToListAsync();
        }

        public async Task CreateAsync(StockEntry stockEntry)
        {
            _context.StockEntries.Add(stockEntry);
            await _context.SaveChangesAsync();
        }
    }
}
