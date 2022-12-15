using System.Collections.Generic;
using System.Threading.Tasks;

namespace TaskTracker.Repository.Interfaces
{
    // Repository interface contains methods for database working
    public interface IRepository<T>
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync(int id);
        Task<int> CreateAsync(T entity);
        Task UpdateAsync(T entity);
        Task DeleteAsync(T entity);
    }
}
