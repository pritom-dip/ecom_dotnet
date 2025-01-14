using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace AllServices.Services.UserContainer
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();

        Task<User?> GetUserById(int id);

        Task<User?> CreateUser(User user);
    }
}