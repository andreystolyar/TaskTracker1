using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Context;
using TaskTracker.Repository.Interfaces;
using Microsoft.EntityFrameworkCore;
using TaskTracker.Entity;

namespace TaskTracker.Repository
{
    // Implementation of IRepository interface.
    // Works only with classes derived from abstract class BaseEntity.
    public class Repository<T> : IRepository<T>
        where T : BaseEntity
    {
        private readonly MyDbContext _context;
        private readonly DbSet<T> _dbSet;

        public Repository(MyDbContext context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _dbSet.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task<int> CreateAsync(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();

            return entity.Id;
        }

        public async Task UpdateAsync(T entity)
        {
            _dbSet.Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(T task)
        {
            _dbSet.Remove(task);
            await _context.SaveChangesAsync();
        }
    }
}
