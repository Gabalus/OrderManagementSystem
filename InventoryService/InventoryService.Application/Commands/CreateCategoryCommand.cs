using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace InventoryService.Application.Commands
{
    public class CreateCategoryCommand : IRequest<Guid>
    {
        public string Name { get; set; }
    }

    public class CreateCategoryCommandHandler : IRequestHandler<CreateCategoryCommand, Guid>
    {
        private readonly ICategoryRepository _categoryRepository;

        public CreateCategoryCommandHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Guid> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var category = new Category
            {
                Id = Guid.NewGuid(),
                Name = request.Name
            };

            await _categoryRepository.CreateAsync(category);

            return category.Id;
        }
    }
}
