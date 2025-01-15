using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DataAccess.Dtos.UserDto;
using Models;

namespace AllServices.Services.UserContainer
{
    public interface IUserService
    {
        List<User> GetAllUsers();

        Task<User?> GetUserById(int id);

        Task<User?> CreateUser(CreateUserDto userDto);

        Task<User?> DeleteUser(int id);

        Task<User?> UpdateUser(UpdateUserDto updateUserDto, int id);
    }
}