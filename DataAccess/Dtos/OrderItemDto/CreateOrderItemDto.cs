using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DataAccess.Dtos.OrderItemDto
{
    public class CreateOrderItemDto
    {
        public required int ProductId { get; set; }
        public required int Quantity { get; set; }
        public required decimal Price { get; set; }
        public required decimal Total { get; set; }
    }
}