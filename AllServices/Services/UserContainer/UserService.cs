using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.UserDto;
using DataAccess.Mappers;
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

        public async Task<User?> CreateUser(CreateUserDto userDto)
        {
            var user = userDto.ToCreateUser();
            var newUser = await _userService.Create(user);
            return newUser;
        }

        public async Task<User?> DeleteUser(int id)
        {
            var user = await _userService.GetById(id);
            if(user == null){
                return null;
            }
            await _userService.Delete(user);
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

        public async Task<User?> UpdateUser(UpdateUserDto updateUserDto, int id)
        {
            var existingUser = await _userService.GetById(id);
            if(existingUser == null){
                return null;
            }

            existingUser.Username = updateUserDto.Username;
            existingUser.Email = updateUserDto.Email;
            existingUser.Password = updateUserDto.Password;

            await _userService.Update(existingUser);
            return existingUser;
        }
    }
}