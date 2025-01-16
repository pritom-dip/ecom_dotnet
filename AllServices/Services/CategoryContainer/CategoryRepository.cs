using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Models;
using AllServices.Services.RepositoryContainer;

namespace AllServices.Services.CategoryContainer
{
    public class CategoryRepository : Repository<Category>, IcategoryRepository
    {
        private readonly ApplicationDbContext _categoryRepo;
        public CategoryRepository(ApplicationDbContext context) : base(context)
        {
            _categoryRepo = context;
        }
    }
}