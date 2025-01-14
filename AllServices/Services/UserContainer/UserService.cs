using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace AllServices.Services.UserContainer
{
    public class UserService : IUserService
    {

        private readonly IUserRepository _userService;

        public UserService(IUserRepository _userRepo)
        {
            _userService = _userRepo;
        }
        public async Task<List<User>> GetAllUsers()
        {
            var AllUsers = await _userService.Get();
            return AllUsers;
        }
    }
}