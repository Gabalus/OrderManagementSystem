using System.Threading.Tasks;
using System;
using OrderService.Application.DTOs;

namespace OrderService.Application.Interfaces
{
    public interface ICustomerServiceClient
    {
        Task<CustomerDto> GetCustomerByIdAsync(Guid customerId);
    }
}
