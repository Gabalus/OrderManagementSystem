using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using CustomerService.Domain.Models;

namespace CustomerService.Domain.Interfaces
{
    public interface ICustomerRepository
    {
        Task<Customer> GetByIdAsync(Guid id);
        Task<IEnumerable<Customer>> SearchAsync(string query);
        Task CreateAsync(Customer customer);
        Task UpdateAsync(Customer customer);
        Task DeleteAsync(Guid id);
    }
}
