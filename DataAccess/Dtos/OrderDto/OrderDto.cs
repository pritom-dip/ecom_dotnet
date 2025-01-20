using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.PaymentDto;
using Models;

namespace DataAccess.Dtos.OrderDto
{
    public class OrderDto
    {
        [Required]
        public required int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public required decimal Total { get; set; }
        public string? ShippingAddress { get; set; }
        public string? PaymentStatus { get; set; }
        public string? OrderStatus { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Customer? Customer { get; set; }
        public List<OrderItemDto.OrderItemDto> OrderItems { get; set; } = new List<OrderItemDto.OrderItemDto>();
        public PaymentDto.PaymentDto Payment { get; set; }
        public Shipping Shipping { get; set; }
    }
}