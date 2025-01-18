using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.CategoryContainer;
using DataAccess.Dtos.CategoryDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controller
{
    [ApiController]
    [Route("/api/category")]
    public class CategoryController : ControllerBase
    {

        private readonly ICategoryService _categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            _categoryService = categoryService;
        }

        [HttpGet]
        public IActionResult GetAllCategories([FromQuery] QueryObject queryObject)
        {
            var results = _categoryService.GetAllCategories(queryObject);
            var categories = results.Select(c => c.ToCategoryDto());
            return Ok(categories);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetCategoryById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }
            var category = await _categoryService.GetCategoryById(id);

            if (category == null)
            {
                return NotFound();
            }
            return Ok(category.ToCategoryDto());
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryDto categoryDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newCategory = await _categoryService.CreateCategory(categoryDto);
            if (newCategory == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetCategoryById), new { id = newCategory.Id }, newCategory.ToCategoryDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            await _categoryService.DeleteCategory(id);
            return Ok(null);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateCategory([FromBody] UpdateCategoryDto upcateCategoryDto, int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedCategory = await _categoryService.UpdateCategory(upcateCategoryDto, id);
            if (updatedCategory == null)
            {
                return NotFound();
            }
            return Ok(updatedCategory.ToCategoryDto());
        }
    }
}