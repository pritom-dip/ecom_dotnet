using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CustomerDto;
using Models;

namespace DataAccess.Mappers
{
    public static class CustomerMappers
    {
        public static CustomerDto ToCustomerDto(this Customer customer)
        {
            return new CustomerDto
            {
                Id = customer.Id,
                UserId = customer.UserId,
                FirstName = customer.FirstName,
                LastName = customer.LastName,
                Address = customer.Address,
                City = customer.City,
                PostalCode = customer.PostalCode,
                Country = customer.Country,
                Phone = customer.Phone,
                CreateAt = customer.CreateAt,
                UpdatedAt = customer.UpdatedAt,
                Orders = customer.Orders
            };
        }


        public static Customer ToCreateCustomerDto(this CreateCustomerDto createCustomerDto)
        {
            return new Customer
            {
                UserId = createCustomerDto.UserId,
                FirstName = createCustomerDto.FirstName,
                LastName = createCustomerDto.LastName,
                Address = createCustomerDto.Address,
                City = createCustomerDto.City,
                PostalCode = createCustomerDto.PostalCode,
                Country = createCustomerDto.Country,
                Phone = createCustomerDto.Phone,
            };
        }

        public static Customer ToUpdateCustomerDto(this UpdateCustomerDto updateCustomerDto)
        {
            return new Customer
            {
                UserId = updateCustomerDto.UserId,
                FirstName = updateCustomerDto.FirstName,
                LastName = updateCustomerDto.LastName,
                Address = updateCustomerDto.Address,
                City = updateCustomerDto.City,
                PostalCode = updateCustomerDto.PostalCode,
                Country = updateCustomerDto.Country,
                Phone = updateCustomerDto.Phone,
            };
        }
    }
}