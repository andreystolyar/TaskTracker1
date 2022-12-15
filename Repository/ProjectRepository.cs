using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using TaskTracker.Context;
using TaskTracker.Entity;
using TaskTracker.Repository.Interfaces;

namespace TaskTracker.Repository
{
    public class ProjectRepository : Repository<ProjectEntity>, IProjectRepository
    {
        private readonly MyDbContext _context;
        private readonly DbSet<ProjectEntity> _dbSet;

        public ProjectRepository(MyDbContext context) : base(context)
        {
            _context = context;
            _dbSet = context.Set<ProjectEntity>();
        }

        public async Task<IEnumerable<ProjectEntity>> GetAllAsync()
        {
            return await _dbSet
                .Include(x => x.Tasks)
                .ToListAsync();
        }

        public async Task<ProjectEntity> GetByIdAsync(int id)
        {
            return await _dbSet
                .Include(x => x.Tasks)
                .FirstOrDefaultAsync(e => e.Id == id);
        }
    }
}
