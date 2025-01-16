using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AllServices.Services.RepositoryContainer
{
    public interface IRepository<T> where T:class
    {
        IQueryable<T> Get();
        Task<T?> GetById(int id);
        Task<T> Create(T model);
        Task<T?> Delete(T model);
        Task<T> Update(T model);
        T? GetFirstOrDefault(Func<T, bool> predicate);
    }
}