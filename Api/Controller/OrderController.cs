using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.OrderContainer;
using DataAccess.Dtos.OrderDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controller
{
    [ApiController]
    [Route("/api/order")]
    public class OrderController : ControllerBase
    {
        private readonly IOrderService _orderService;

        public OrderController(IOrderService orderService)
        {
            _orderService = orderService;
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateOrderDto createOrderDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = await _orderService.CreateOrder(createOrderDto);
            return CreatedAtAction(nameof(Get), new { id = order.Id }, order.ToOrderDto());
        }

        [HttpGet]
        [Route("{id}")]
        public async Task<IActionResult> Get(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            var order = await _orderService.GetOrder(id);

            if (order == null)
            {
                return NotFound();
            }
            return Ok(order.ToOrderDto());
        }
    }
}