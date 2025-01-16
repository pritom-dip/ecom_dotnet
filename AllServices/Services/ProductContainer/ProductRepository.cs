using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using DataAccess.Data;
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
    }
}