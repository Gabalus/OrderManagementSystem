using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace InventoryService.Application.Queries
{
    public class GetCategoryByIdQuery : IRequest<Category>
    {
        public Guid Id { get; set; }
    }

    public class GetCategoryByIdQueryHandler : IRequestHandler<GetCategoryByIdQuery, Category>
    {
        private readonly ICategoryRepository _categoryRepository;

        public GetCategoryByIdQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<Category> Handle(GetCategoryByIdQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.GetByIdAsync(request.Id);
        }
    }
}
