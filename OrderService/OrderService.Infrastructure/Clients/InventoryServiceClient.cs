using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Clients
{
    public class InventoryServiceClient : IInventoryServiceClient
    {
        private readonly HttpClient _httpClient;

        public InventoryServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<ProductDto> GetProductByIdAsync(Guid productId)
        {
            var response = await _httpClient.GetAsync($"/{productId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<ProductDto>();
        }
    }
}
