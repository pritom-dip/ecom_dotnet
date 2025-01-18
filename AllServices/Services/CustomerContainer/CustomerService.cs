using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CustomerDto;
using DataAccess.Mappers;
using Models;
using Utility.ExtensionHelpers;

namespace AllServices.Services.CustomerContainer
{
    public class CustomerService : ICustomerService
    {
        private readonly ICustomerRepository _customerRepo;

        public CustomerService(ICustomerRepository customerRepo)
        {
            _customerRepo = customerRepo;
        }

        public async Task<Customer?> CreateCustomer(CreateCustomerDto customerDto)
        {
            var customer = customerDto.ToCreateCustomerDto();
            var newCustomer = await _customerRepo.Create(customer);
            return newCustomer;
        }


        public async Task<Customer?> DeleteCustomer(int id)
        {
            var customer = await _customerRepo.GetById(id);
            if (customer == null)
            {
                return null;
            }
            await _customerRepo.Delete(customer);
            return customer;
        }

        public List<Customer> GetAllCustomers(QueryObject queryObject)
        {
            var customers = _customerRepo.Get().Paginate(queryObject.PageNumber, queryObject.PerPage).ToList();
            return customers;
        }

        public async Task<Customer?> GetCustomerById(int id)
        {
            return await _customerRepo.GetById(id);
        }

        public async Task<Customer?> UpdateCustomer(UpdateCustomerDto updateCustomerDto, int id)
        {
            var existingCustomer = await _customerRepo.GetById(id);
            if (existingCustomer == null)
            {
                return null;
            }

            existingCustomer.UserId = updateCustomerDto.UserId;
            existingCustomer.FirstName = updateCustomerDto.FirstName;
            existingCustomer.LastName = updateCustomerDto.LastName;
            existingCustomer.Address = updateCustomerDto.Address;
            existingCustomer.City = updateCustomerDto.City;
            existingCustomer.PostalCode = updateCustomerDto.PostalCode;
            existingCustomer.Country = updateCustomerDto.Country;
            existingCustomer.Phone = updateCustomerDto.Phone;


            return existingCustomer;

        }
    }
}