using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using DataAccess.Data;

namespace AllServices.Services.RepositoryContainer
{
    public class Repository<T> : IRepository<T> where T : class
    {

        private readonly ApplicationDbContext _repo;

        public Repository(ApplicationDbContext context)
        {
            _repo = context;
        }

        public virtual async Task<T> Create(T data)
        {
            await _repo.Set<T>().AddAsync(data);
            await _repo.SaveChangesAsync();
            return data;
        }

        public virtual async Task<T?> Delete(T data)
        {
            _repo.Set<T>().Remove(data);
            await _repo.SaveChangesAsync();
            return data;
        }

        public virtual IQueryable<T> Get()
        {
            return _repo.Set<T>().AsQueryable();
        }

        public virtual async Task<T?> GetById(int id)
        {
            return await _repo.Set<T>().FindAsync(id);
        }

        public virtual async Task<T> Update(T data)
        {
            await _repo.SaveChangesAsync();
            return data;
        }
    }
}