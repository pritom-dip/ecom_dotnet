using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Dtos.CustomerDto
{
    public class UpdateCustomerDto
    {
        [Required]
        public int UserId { get; set; }
        [Required]
        public string FirstName { get; set; }
        [Required]
        public string LastName { get; set; }
        public string? Address { get; set; } = String.Empty;
        public string? City { get; set; } = String.Empty;
        public string? PostalCode { get; set; } = String.Empty;
        public string? Country { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public User? User { get; set; }
    }
}