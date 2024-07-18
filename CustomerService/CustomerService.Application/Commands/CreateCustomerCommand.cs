using MediatR;
using System;

namespace CustomerService.Application.Commands
{
    public class CreateCustomerCommand : IRequest<Guid>
    {
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}