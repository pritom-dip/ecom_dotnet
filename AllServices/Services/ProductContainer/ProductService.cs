using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using DataAccess.Dtos.ProductDto;
using DataAccess.Mappers;
using Microsoft.EntityFrameworkCore;
using Models;
using Utility.ExtensionHelpers;

namespace AllServices.Services.ProductContainer
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        public ProductService(IProductRepository productRepo)
        {
            _productRepo = productRepo;
        }

        public async Task<Product?> CreateProduct(CreateProductDto createProductDto)
        {
            var product = createProductDto.ToCreateProductDto();
            var createdProduct = await _productRepo.Create(product);
            return createdProduct;
        }

        public async Task<Product?> DeleteProduct(int id)
        {
            var product = await _productRepo.GetById(id);
            if(product == null)
            {
                return null;
            }
            await _productRepo.Delete(product);
            return product;
        }

        public List<Product> GetAllProducts()
        {
            var products = _productRepo.Get().Include(p => p.Category).Include(p => p.Reviews).Paginate(1,3).ToList();
            return products;
        }

        public async Task<Product?> GetProductById(int id)
        {
            return await _productRepo.GetById(id);
        }

        public async Task<Product?> UpdateProduct(UpdateProductDto updateProduct, int id)
        {
            var existingProduct = await _productRepo.GetById(id);
            if(existingProduct == null)
            {
                return null;
            }

            existingProduct.Name = updateProduct.Name;
            existingProduct.Price = updateProduct.Price;
            existingProduct.Description = updateProduct.Description ?? existingProduct.Description;
            existingProduct.CategoryId = updateProduct.CategoryId;
            existingProduct.SKU = updateProduct.SKU;
            existingProduct.Image = updateProduct.Image ?? existingProduct.Image;
            existingProduct.StockQty = updateProduct.StockQty;

            await _productRepo.Update(existingProduct);
            return existingProduct;

        }
    }
}