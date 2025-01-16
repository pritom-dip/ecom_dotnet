using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace DataAccess.Dtos.ProductDto
{
    public class CreateProductDto
    {
        public int? CategoryId { get; set; }
        [Required]
        public required string Name { get; set; }
        public string? Description { get; set; } = String.Empty;
        [Required]
        public decimal Price { get; set; }
        [Required]
        public int StockQty { get; set; }
        [Required]
        public required string SKU { get; set; }
        public string? Image { get; set; } = "https://via.placeholder.com/150";

    }
}