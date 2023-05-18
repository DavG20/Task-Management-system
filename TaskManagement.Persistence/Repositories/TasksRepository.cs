using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence.Repositories
{
    public class TasksRepository : GenericRepository<Tasks>, ITasksRepository
    {
        private readonly TaskManagementDbContext _context;
        public TasksRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
