using InventoryService.Application.Commands;
using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace InventoryService.Application.Handlers
{
    public class DeleteProductCommandHandler : IRequestHandler<DeleteProductCommand>
    {
        private readonly IProductRepository _productRepository;

        public DeleteProductCommandHandler(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<Unit> Handle(DeleteProductCommand request, CancellationToken cancellationToken)
        {
            await _productRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
