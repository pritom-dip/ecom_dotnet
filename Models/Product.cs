using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Models
{
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public int? CategoryId { get; set; }
        public required string Name { get; set; }
        public string? Description { get; set; }
        public required decimal Price { get; set; }
        public string? Image { get; set; }
        public int StockQty { get; set; }
        public required string SKU { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;

        public Category? Category { get; set; }

        public List<OrderItem>? OrderItems { get; set; }

        public List<Review> Reviews { get; set; } = new List<Review>();
    }
}