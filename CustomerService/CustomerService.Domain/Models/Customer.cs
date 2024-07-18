using OrderService.Domain.Models;
using System;
using System.Collections.Generic;

namespace CustomerService.Domain.Models
{
    public class Customer
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public DateTime DateOfBirth { get; set; }
    }
}
