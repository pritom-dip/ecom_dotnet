using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using Models;

namespace AllServices.Services.ProductContainer
{
    public interface IProductRepository : IRepository<Product>
    {
        
    }
}