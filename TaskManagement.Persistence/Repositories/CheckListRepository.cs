
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Persistence.Repositories;

namespace TaskManagement.Persistence.Repositories
{
    public class CheckListRepository : GenericRepository<CheckList>, ICheckListRepository
    {
        private readonly TaskManagementDbContext _dbContext;
        public CheckListRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task<List<CheckList>> GetChecklistwithTasks()
        {
            return await _dbContext.Set<CheckList>().Include(x => x.TasksId).AsNoTracking().ToListAsync();
        }

        public async Task<CheckList> Get(int id)
        {
            return await _dbContext.Set<CheckList>().Include(x => x.TasksId).FirstOrDefaultAsync(b => b.Id == id);
        }

        public async Task<List<CheckList>> GetBlogs()
        {
            return await _dbContext.Set<CheckList>().Include(x => x.TasksId).AsNoTracking().ToListAsync();
        }

    }
}
