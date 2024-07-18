using InventoryService.Application.Commands;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class UpdateProductCommandHandler : IRequestHandler<UpdateProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public UpdateProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(UpdateProductCommand request, CancellationToken cancellationToken)
        {
            var product = await _productRepository.GetByIdAsync(request.Id);
            if (product == null)
            {
                throw new KeyNotFoundException("Product not found");
            }

            product.Name = request.Name;
            product.CategoryId = request.CategoryId;
            product.Stock = request.Stock;
            product.Price = request.Price;

            await _productRepository.UpdateAsync(product);

            return Unit.Value;
        }
    }
}
