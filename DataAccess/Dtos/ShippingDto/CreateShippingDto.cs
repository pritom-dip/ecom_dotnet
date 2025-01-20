using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Dtos.ShippingDto
{
    public class CreateShippingDto
    {
        public required string ShippingMethod { get; set; }
        public required string TrackingNumber { get; set; }
        public required string ShippingStatus { get; set; }
        public required DateTime EstimatedArrival { get; set; }
        public DateTime ShippingDate { get; set; } = DateTime.Now.Add(TimeSpan.FromDays(7));
    }
}