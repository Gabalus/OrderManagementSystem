using InventoryService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InventoryService.Domain.Interfaces
{
    public interface ICategoryRepository
    {
        Task CreateAsync(Category category);
        Task<Category> GetByIdAsync(Guid id);
        Task<IEnumerable<Category>> SearchAsync(string query);
        Task UpdateAsync(Category category);
        Task DeleteAsync(Guid id);
    }
}
