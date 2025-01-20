using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderDto;
using Models;

namespace DataAccess.Dtos.PaymentDto
{
    public class PaymentDto
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public string PaymentMethod { get; set; }
        public string PaymentStatus { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public OrderDto.OrderDto Order { get; set; }
    }
}