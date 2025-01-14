using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;

namespace AllServices.Services.UserContainer
{
    public interface IUserRepository
    {
        Task<List<User>> Get();

        void Create(User user);
    }
}