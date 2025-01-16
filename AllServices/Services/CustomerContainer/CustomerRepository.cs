using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Services.CustomerContainer
{
    public class CustomerRepository : Repository<Customer>, ICustomerRepository
    {
        private readonly ApplicationDbContext _customerRepo;

        public CustomerRepository(ApplicationDbContext context) : base(context)
        {
            _customerRepo = context;
        }

        public async Task<bool> CustomerExists(int id)
        {
            return await _customerRepo.Users.AnyAsync(x => x.Id == id);
        }
    }
}