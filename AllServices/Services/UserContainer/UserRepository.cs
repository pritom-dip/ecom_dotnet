using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Data;
using Microsoft.EntityFrameworkCore;
using Models;

namespace AllServices.Services.UserContainer
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationDbContext _userRepo;

        public UserRepository(ApplicationDbContext context)
        {
            _userRepo = context;
        }

        public async Task<User> Create(User user)
        {
            await _userRepo.Users.AddAsync(user);
            await _userRepo.SaveChangesAsync();
            return user;
        }

        public async Task<List<User>> Get()
        {
            return await _userRepo.Users.ToListAsync();
        }

        public async Task<User?> GetById(int id)
        {
            return await _userRepo.Users.FirstOrDefaultAsync(x => x.Id == id);
        }
    }
}