using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.ProductDto;
using Models;

namespace DataAccess.Mappers
{
    public static class ProductMappers
    {
        public static ProductDto ToProductDto(this Product product){
            return new ProductDto
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Price = product.Price,
                Image = product.Image,
                StockQty = product.StockQty,
                SKU = product.SKU,
                CreateAt = product.CreateAt,
                UpdatedAt = product.UpdatedAt,
                Category = product.Category != null ? product.Category.ToCategoryDto() : null,
                Reviews = product.Reviews.Select(r => r.ToReviewDto()).ToList()
            };
        }

        public static Product ToCreateProductDto(this CreateProductDto createProductDto){
            return new Product
            {
                CategoryId = createProductDto.CategoryId,
                Name = createProductDto.Name,
                Description = createProductDto.Description ?? string.Empty,
                Price = createProductDto.Price,
                Image = createProductDto.Image ?? string.Empty,
                StockQty = createProductDto.StockQty,
                SKU = createProductDto.SKU
            };
        }

        public static Product ToUpdateProductDto(this UpdateProductDto updateProductDto){
            return new Product
            {
                CategoryId = updateProductDto.CategoryId,
                Name = updateProductDto.Name,
                Description = updateProductDto.Description ?? string.Empty,
                Price = updateProductDto.Price,
                Image = updateProductDto.Image ?? string.Empty,
                StockQty = updateProductDto.StockQty,
                SKU = updateProductDto.SKU
            };
        }
    }
}