using InventoryService.Application.Queries;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class SearchProductsQueryHandler : IRequestHandler<SearchProductsQuery, IEnumerable<Product>>
    {
        private readonly IProductRepository _productRepository;

        public SearchProductsQueryHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Product>> Handle(SearchProductsQuery request, CancellationToken cancellationToken)
        {
            return await _productRepository.SearchAsync(request.Query);
        }
    }
}
