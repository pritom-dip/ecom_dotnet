using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using Models;

namespace DataAccess.Dtos.ProductDto
{
    public class ProductDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public decimal Price { get; set; }
        public string? Image { get; set; }
        public int StockQty { get; set; }
        public string SKU { get; set; }
        public DateTime CreateAt { get; set; } = DateTime.Now;
        public DateTime UpdatedAt { get; set; } = DateTime.Now;
        public CategoryDto.CategoryDto? Category { get; set; }
        public List<ReviewDto.ReviewDto> Reviews { get; set; } = new List<ReviewDto.ReviewDto>();
    }
}