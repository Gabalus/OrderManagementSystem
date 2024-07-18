using InventoryService.Application.Commands;
using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class CreateProductCommandHandler : IRequestHandler<CreateProductCommand, Guid>
    {
        private readonly IProductRepository _productRepository;

        public CreateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Guid> Handle(CreateProductCommand request, CancellationToken cancellationToken)
        {
            var product = new Product
            {
                Id = Guid.NewGuid(),
                Name = request.Name,
                CategoryId = request.CategoryId,
                Stock = request.Stock,
                Price = request.Price
            };

            await _productRepository.CreateAsync(product);

            return product.Id;
        }
    }
}
