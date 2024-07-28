using OrderService.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrderService.Application.Interfaces
{
    public interface IInventoryServiceClient
    {
        Task<ProductDto> GetProductByIdAsync(Guid productId);
    }
}