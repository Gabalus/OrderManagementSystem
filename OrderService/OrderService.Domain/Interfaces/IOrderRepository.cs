using OrderService.Domain.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace OrderService.Domain.Repositories
{
    public interface IOrderRepository
    {
        Task<Order> GetByIdAsync(Guid id);
        Task<IEnumerable<Order>> GetAllAsync();
        Task AddAsync(Order order);
        Task UpdateAsync(Order order);
        Task DeleteAsync(Guid id);
        Task<IEnumerable<Order>> SearchAsync(string query);
        Task CreateAsync(Order order);
    }
}
