using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.ProductContainer;
using DataAccess.Dtos.ProductDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controller
{
    [ApiController]
    [Route("api/product")]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _productService;
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        public IActionResult GetProducts([FromQuery] QueryObject queryObject)
        {
            var results = _productService.GetAllProducts(queryObject);
            var products = results.Select(p => p.ToProductDto());
            return Ok(products);
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> GetProductbyId(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.GetProductById(id);
            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }

        [HttpPost]
        public async Task<IActionResult> AddProduct([FromBody] CreateProductDto createProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var product = await _productService.CreateProduct(createProductDto);
            if (product == null)
            {
                return BadRequest();
            }
            return CreatedAtAction(nameof(GetProductbyId), new { Id = product.Id }, product.ToProductDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            await _productService.DeleteProduct(id);
            return NoContent();
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto updateProductDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var product = await _productService.UpdateProduct(updateProductDto, id);

            if (product == null)
            {
                return NotFound();
            }
            return Ok(product.ToProductDto());
        }
    }
}