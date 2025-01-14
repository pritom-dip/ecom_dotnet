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

        public async Task<User?> CreateUser(User user)
        {
            var newUser = await _userService.Create(user);
            return newUser;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);
            if(user == null){
                return null;
            }
            _userService.Delete(user);
            return user;
        }

        public async Task<List<User>> GetAllUsers()
        {
            var AllUsers = await _userService.Get();
            return AllUsers;
        }

        public async Task<User?> GetUserById(int id)
        {
            var user = await _userService.GetById(id);
            return user;
        }
    }
}