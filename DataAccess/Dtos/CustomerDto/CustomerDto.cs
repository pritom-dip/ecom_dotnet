using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Dtos.CustomerDto
{
    public class CustomerDto
    {
        [Key]
        public int Id { get; set; }
        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public string? City { get; set; } = String.Empty;
        public string? PostalCode { get; set; } = String.Empty;
        public string? Country { get; set; } = String.Empty;
        public string Phone { get; set; } = String.Empty;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}