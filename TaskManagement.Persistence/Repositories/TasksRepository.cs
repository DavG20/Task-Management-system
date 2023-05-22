using TaskManagement.Application.Contracts.Persistence;
using domain = TaskManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace TaskManagement.Persistence.Repositories
{
    public class TasksRepository : GenericRepository<Domain.Task>, ITasksRepository
    {
        private readonly TaskManagementDbContext _dbContext;
        public TasksRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<List<domain.Task>> GetTaskssWithChecklist()
        {
            return await _dbContext.Set<domain.Task>().Include(x => x.CheckLists).AsNoTracking().ToListAsync();
        }

        public async Task<domain.Task> Get(int id)
        {
            return await _dbContext.Set<domain.Task>().Include(x => x.CheckLists).Include(x => x.UserId).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<domain.Task>> GetTasks()
        {
            return await _dbContext.Set<domain.Task>().Include(x => x.CheckLists).Include(x => x.UserId).AsNoTracking().ToListAsync();
        }


    }
}
