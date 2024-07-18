using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces
{
    public interface IProductRepository
    {
        Task CreateAsync(Product product);
        Task<Product> GetByIdAsync(Guid id);
        Task<IEnumerable<Product>> SearchAsync(string query);
        Task UpdateAsync(Product product);
        Task DeleteAsync(Guid id);
    }
}
