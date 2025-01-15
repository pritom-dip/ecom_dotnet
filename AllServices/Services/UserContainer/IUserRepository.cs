using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AllServices.Services.RepositoryContainer;
using Models;

namespace AllServices.Services.UserContainer
{
    public interface IUserRepository : IRepository<User>
    {
        Task<bool> UserExists(int id);
    }
}