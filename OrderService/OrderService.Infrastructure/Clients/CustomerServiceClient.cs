using OrderService.Application.DTOs;
using OrderService.Application.Interfaces;
using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace OrderService.Infrastructure.Clients
{
    public class CustomerServiceClient : ICustomerServiceClient
    {
        private readonly HttpClient _httpClient;

        public CustomerServiceClient(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CustomerDto> GetCustomerByIdAsync(Guid customerId)
        {
            var response = await _httpClient.GetAsync($"/{customerId}");
            response.EnsureSuccessStatusCode();
            return await response.Content.ReadFromJsonAsync<CustomerDto>();
        }
    }
}
