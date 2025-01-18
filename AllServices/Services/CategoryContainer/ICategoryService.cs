using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using Models;

namespace AllServices.Services.CategoryContainer
{
    public interface ICategoryService
    {
        List<Category> GetAllCategories(QueryObject queryObject);
        Task<Category?> GetCategoryById(int id);

        Task<Category?> CreateCategory(CreateCategoryDto categoryDto);

        Task<Category?> DeleteCategory(int id);

        Task<Category?> UpdateCategory(UpdateCategoryDto updateCategoryDto, int id);
    }
}