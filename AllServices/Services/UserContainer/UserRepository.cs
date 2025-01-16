using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Services.UserContainer
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        private readonly ApplicationDbContext _userRepo;

        public UserRepository(ApplicationDbContext context) : base(context)
        {
            _userRepo = context;
        }

        public async Task<bool> UserExists(int id)
        {
            return await _userRepo.Users.AnyAsync(x => x.Id == id);
        }
    }
}