using InventoryService.Domain.Interfaces;
using InventoryService.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace InventoryService.Application.Queries
{
    public class SearchCategoriesQuery : IRequest<IEnumerable<Category>>
    {
        public string Query { get; set; }
    }

    public class SearchCategoriesQueryHandler : IRequestHandler<SearchCategoriesQuery, IEnumerable<Category>>
    {
        private readonly ICategoryRepository _categoryRepository;

        public SearchCategoriesQueryHandler(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public async Task<IEnumerable<Category>> Handle(SearchCategoriesQuery request, CancellationToken cancellationToken)
        {
            return await _categoryRepository.SearchAsync(request.Query);
        }
    }
}
