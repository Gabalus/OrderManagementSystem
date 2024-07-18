using System;

namespace InventoryService.Domain.Models
{
    public class StockEntry
    {
        public Guid Id { get; set; }
        public Guid ProductId { get; set; }
        public int Quantity { get; set; }
        public DateTime Date { get; set; }

        public Product Product { get; set; }
    }
}
