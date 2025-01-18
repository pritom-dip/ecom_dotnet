using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.CustomerDto;
using Models;

namespace AllServices.Services.CustomerContainer
{
    public interface ICustomerService
    {
        List<Customer> GetAllCustomers(QueryObject queryObject);

        Task<Customer?> GetCustomerById(int id);

        Task<Customer?> CreateCustomer(CreateCustomerDto customerDto);

        Task<Customer?> DeleteCustomer(int id);

        Task<Customer?> UpdateCustomer(UpdateCustomerDto updateCustomerDto, int id);

    }
}