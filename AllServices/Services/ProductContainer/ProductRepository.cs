using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Services.ProductContainer
{
    public class ProductRepository : Repository<Product>, IProductRepository
    {
        private readonly ApplicationDbContext _productRepo;
        public ProductRepository(ApplicationDbContext productRepo) : base(productRepo)
        {
            _productRepo = productRepo;
        }

        public override async Task<Product?> GetById(int id)
        {
            return await _productRepo.Products.Include(p => p.Category).Include(p => p.Reviews).FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}