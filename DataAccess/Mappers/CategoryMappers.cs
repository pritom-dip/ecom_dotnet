using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CategoryDto;
using Models;

namespace DataAccess.Mappers
{
    public static class CategoryMappers
    {
        public static CategoryDto ToCategoryDto(this Category category){
            return new CategoryDto {
                Id = category.Id,
                Name = category.Name,
                Description = category.Description,
                DisplayOrder = category.DisplayOrder,
                CreateAt = category.CreateAt,
                UpdatedAt = category.UpdatedAt,
            };
        }

        public static Category ToCreateCategoryDto(this CreateCategoryDto createCategoryDto){
            return new Category {
                Name = createCategoryDto.Name,
                Description = createCategoryDto.Description,
                DisplayOrder = createCategoryDto.DisplayOrder,
            };
        }

        public static Category ToUpdateCategoryDto(this UpdateCategoryDto updateCategoryDto){
            return new Category {
                Name = updateCategoryDto.Name,
                Description = updateCategoryDto.Description,
                DisplayOrder = updateCategoryDto.DisplayOrder,
            };
        }
    }
}