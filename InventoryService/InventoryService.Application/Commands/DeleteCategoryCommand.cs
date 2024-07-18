using InventoryService.Domain.Interfaces;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace InventoryService.Application.Commands
{
    public class DeleteCategoryCommand : IRequest
    {
        public Guid Id { get; set; }
    }

    public class DeleteCategoryCommandHandler : IRequestHandler<DeleteCategoryCommand>
    {
        private readonly ICategoryRepository _categoryRepository;

        public DeleteCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Unit> Handle(DeleteCategoryCommand request, CancellationToken cancellationToken)
        {
            await _categoryRepository.DeleteAsync(request.Id);
            return Unit.Value;
        }
    }
}
