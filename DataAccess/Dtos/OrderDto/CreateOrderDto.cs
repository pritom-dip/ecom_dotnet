using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.OrderItemDto;
using DataAccess.Dtos.ShippingDto;
using Models;

namespace DataAccess.Dtos.OrderDto
{
    public class CreateOrderDto
    {
        [Required]
        public required int CustomerId { get; set; }
        public DateTime OrderDate { get; set; } = DateTime.Now;
        [Required]
        public required decimal Total { get; set; }
        public string? ShippingAddress { get; set; }
        public required List<CreateOrderItemDto> OrderItems { get; set; }
        public required CreateShippingDto Shipping { get; set; }
    }
}