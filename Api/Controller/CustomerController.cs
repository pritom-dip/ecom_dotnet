using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.CustomerContainer;
using DataAccess.Dtos.CustomerDto;
using DataAccess.Mappers;
using Microsoft.AspNetCore.Mvc;
using Models;

namespace Api.Controller
{
    [ApiController]
    [Route("/api/customer")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomerService _customerService;

        public CustomerController(ICustomerService customerService)
        {
            _customerService = customerService;
        }

        [HttpGet]
        public IActionResult GetCustomers([FromQuery] QueryObject queryObject)
        {
            var results = _customerService.GetAllCustomers(queryObject);
            var customers = results.Select(customer => customer.ToCustomerDto());
            return Ok(customers);
        }

        [HttpGet]
        [Route("{id}")]

        public async Task<IActionResult> GetCustomerById(int id)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var user = await _customerService.GetCustomerById(id);
            if (user == null)
            {
                return NotFound();
            }

            return Ok(user.ToCustomerDto());
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] CreateCustomerDto customerDto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var newCustomer = await _customerService.CreateCustomer(customerDto);

            if (newCustomer == null)
            {
                return BadRequest();
            }

            return CreatedAtAction(nameof(GetCustomerById), new { id = newCustomer.Id }, newCustomer.ToCustomerDto());
        }

        [HttpDelete]
        [Route("{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var customer = await _customerService.DeleteCustomer(id);
            if (customer == null)
            {
                return NotFound();
            }
            return Ok(null);
        }

        [HttpPut]
        [Route("{id}")]
        public async Task<IActionResult> UpdateUser(int id, [FromBody] UpdateCustomerDto updateCustomerDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var updatedCustomer = await _customerService.UpdateCustomer(updateCustomerDto, id);

            if (updatedCustomer == null)
            {
                return NotFound();
            }

            return Ok(updatedCustomer.ToCustomerDto());
        }
    }
}