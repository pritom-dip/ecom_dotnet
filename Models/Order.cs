using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Order
    {
        [Key]
        public int Id { get; set; }
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
        public List<OrderItem> OrderItems {get; set;} = new List<OrderItem>();
        public Payment Payment { get; set; }
        public Shipping Shipping { get; set; }

    }
}