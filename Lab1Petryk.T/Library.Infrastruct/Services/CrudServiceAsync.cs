using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Library.Infrastruct.Repositories;

namespace Library.Infrastruct.Services
{
    public class CrudServiceAsync<T> : ICrudServiceAsync<T> where T : class
    {
        private readonly IRepository<T> _repository;

        // ❗ ЄДИНИЙ конструктор – обов’язково з репозиторієм
        public CrudServiceAsync(IRepository<T> repository)
        {
            _repository = repository ?? throw new ArgumentNullException(nameof(repository));
        }

        public async Task<bool> CreateAsync(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            await _repository.AddAsync(element);
            return true;
        }

        public async Task<T?> ReadAsync(int id)
        {
            return await _repository.GetByIdAsync(id);
        }

        public async Task<IEnumerable<T>> ReadAllAsync()
        {
            return await _repository.GetAllAsync();
        }

        public async Task<IEnumerable<T>> ReadAllAsync(int page, int amount)
        {
            var all = await _repository.GetAllAsync();
            return all
                .Skip((page - 1) * amount)
                .Take(amount)
                .ToList();
        }

        public async Task<bool> UpdateAsync(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            await _repository.Update(element);
            return true;
        }

        public async Task<bool> RemoveAsync(T element)
        {
            if (element == null)
                throw new ArgumentNullException(nameof(element));

            await _repository.Delete(element);
            return true;
        }

        public async Task<bool> SaveAsync()
        {
            await _repository.SaveChangesAsync();
            return true;
        }
    }
}
