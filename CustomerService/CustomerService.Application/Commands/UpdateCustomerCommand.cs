using CustomerService.Domain.Interfaces;
using CustomerService.Domain.Models;
using MediatR;
using System.Threading.Tasks;
using System.Threading;
using System;

namespace CustomerService.Application.Commands
{
    public class UpdateCustomerCommand : IRequest
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }

    public class UpdateCustomerCommandHandler : IRequestHandler<UpdateCustomerCommand>
    {
        private readonly ICustomerRepository _customerRepository;

        public UpdateCustomerCommandHandler(ICustomerRepository customerRepository)
        {
            _customerRepository = customerRepository;
        }

        public async Task<Unit> Handle(UpdateCustomerCommand request, CancellationToken cancellationToken)
        {
            var customer = await _customerRepository.GetByIdAsync(request.Id);
 /*           if (customer == null)
            {
                throw new NotFoundException(nameof(Customer), request.Id);
            }*/

            customer.FullName = request.FullName;
            customer.PhoneNumber = request.PhoneNumber;
            customer.Email = request.Email;
            customer.DateOfBirth = request.DateOfBirth;
            await _customerRepository.UpdateAsync(customer);

            return Unit.Value;
        }
    }
}
