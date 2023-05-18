
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using TaskManagement.Persistence.Repositories;

namespace TaskManagement.Persistence.Repositories
{
    public class CheckListRepository : GenericRepository<CheckList>, ICheckListRepository
    {
        private readonly TaskManagementDbContext _context;
        public CheckListRepository(TaskManagementDbContext dbContext) : base(dbContext)
        {
            _context = dbContext;
        }
    }
}
