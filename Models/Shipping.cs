using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Shipping
    {
        [Key]
        public int Id { get; set; }
        public required int OrderId { get; set; }
        public required string ShippingMethod { get; set; }
        public required string TrackingNumber { get; set; }
        public required string ShippingStatus { get; set; }
        public required DateTime EstimatedArrival { get; set; }
        public DateTime ShippingDate { get; set; } = DateTime.Now;
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public Order Order { get; set; }
    }
}