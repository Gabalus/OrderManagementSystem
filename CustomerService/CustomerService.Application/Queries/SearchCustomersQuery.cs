using CustomerService.Domain.Interfaces;
using CustomerService.Domain.Models;
using MediatR;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Threading;

namespace CustomerService.Application.Queries
{
    public class SearchCustomersQuery : IRequest<IEnumerable<Customer>>
    {
        public string Query { get; set; }
    }

    public class SearchCustomersQueryHandler : IRequestHandler<SearchCustomersQuery, IEnumerable<Customer>>
    {
        private readonly ICustomerRepository _customerRepository;

        public SearchCustomersQueryHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<IEnumerable<Customer>> Handle(SearchCustomersQuery request, CancellationToken cancellationToken)
        {
            return await _customerRepository.SearchAsync(request.Query);
        }
    }
}
