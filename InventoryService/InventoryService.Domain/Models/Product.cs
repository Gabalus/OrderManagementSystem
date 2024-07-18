using System;
using System.Collections.Generic;

namespace InventoryService.Domain.Models
{
    public class Product
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public Guid CategoryId { get; set; }
        public int Stock { get; set; }
        public decimal Price { get; set; }

        public Category Category { get; set; }
        public ICollection<StockEntry> StockEntries { get; set; }
    }
}
