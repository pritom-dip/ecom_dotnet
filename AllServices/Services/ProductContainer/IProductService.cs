using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using DataAccess.Dtos.ProductDto;
using Models;

namespace AllServices.Services.ProductContainer
{
    public interface IProductService
    {
        List<Product> GetAllProducts();

        Task<Product?> GetProductById(int id);

        Task<Product?> CreateProduct(CreateProductDto createProductDto);

        Task<Product?> UpdateProduct(UpdateProductDto updateProduct, int id);

        Task<Product?> DeleteProduct(int id);
    }
}