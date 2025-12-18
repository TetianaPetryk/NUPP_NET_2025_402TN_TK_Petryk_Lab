using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Infrastruct.Services
{
    public interface ICrudServiceAsync<T>
    {
        Task<bool> CreateAsync(T element);
        Task<T?> ReadAsync(int id);
        Task<IEnumerable<T>> ReadAllAsync();
        Task<IEnumerable<T>> ReadAllAsync(int page, int amount);
        Task<bool> UpdateAsync(T element);
        Task<bool> RemoveAsync(T element);
    }
}