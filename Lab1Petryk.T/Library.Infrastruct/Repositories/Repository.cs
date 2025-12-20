using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Library.Infrastruct.Context;
using Microsoft.EntityFrameworkCore;

namespace Library.Infrastruct.Repositories
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly LibraryDbContext _context;
        private readonly DbSet<T> _set;

        public Repository(LibraryDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
            _set = _context.Set<T>();   // ❗ без цього _set буде null
        }

        public async Task<T?> GetByIdAsync(int id)
        {
            return await _set.FindAsync(id);
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _set.ToListAsync();
        }

        public async Task AddAsync(T entity)
        {
            await _set.AddAsync(entity);
        }

        public Task Update(T entity)
        {
            _set.Update(entity);
            return Task.CompletedTask;
        }

        public Task Delete(T entity)
        {
            _set.Remove(entity);
            return Task.CompletedTask;
        }

        public async Task SaveChangesAsync()
        {
            await _context.SaveChangesAsync();
        }
    }
}
