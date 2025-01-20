using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Dtos.PaymentDto
{
    public class CreatePaymentDto
    {
        public required int OrderId { get; set; }
        public required string PaymentMethod { get; set; }
        public required decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; } = DateTime.Now;
    }
}