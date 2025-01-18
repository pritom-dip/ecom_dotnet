using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using DataAccess.Mappers;
using Models;
using Utility.ExtensionHelpers;

namespace AllServices.Services.CategoryContainer
{
    public class CategoryService : ICategoryService
    {
        private readonly IcategoryRepository _categoryRepo;

        public CategoryService(IcategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public async Task<Category?> CreateCategory(CreateCategoryDto categoryDto)
        {
            var category = categoryDto.ToCreateCategoryDto();
            var newCategory = await _categoryRepo.Create(category);
            return newCategory;
        }

        public async Task<Category?> DeleteCategory(int id)
        {
            var category = await _categoryRepo.GetById(id);
            if (category == null)
            {
                return null;
            }

            await _categoryRepo.Delete(category);
            return category;
        }

        public List<Category> GetAllCategories(QueryObject queryObject)
        {
            var categories = _categoryRepo.Get().SortBy().Paginate(queryObject.PageNumber, queryObject.PerPage).ToList();
            return categories;
        }

        public async Task<Category?> GetCategoryById(int id)
        {
            return await _categoryRepo.GetById(id);
        }

        public async Task<Category?> UpdateCategory(UpdateCategoryDto updateCategoryDto, int id)
        {
            var existingCategory = await _categoryRepo.GetById(id);

            if (existingCategory == null)
            {
                return null;
            }

            existingCategory.Name = updateCategoryDto.Name;
            existingCategory.Description = updateCategoryDto.Description;
            existingCategory.DisplayOrder = updateCategoryDto.DisplayOrder;

            await _categoryRepo.Update(existingCategory);
            return existingCategory;

        }
    }
}