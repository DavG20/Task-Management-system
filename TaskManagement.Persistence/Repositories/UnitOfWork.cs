using TaskManagement.Application.Contracts.Persistence;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Persistence.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {

        private readonly TaskManagementDbContext _context;

        
        private ITasksRepository _tasksRepository;
        private ICheckListRepository _checklistRepository;

       
        public UnitOfWork(TaskManagementDbContext context)
        {
            _context = context;
        }

        

        public ITasksRepository TasksRepository
        {
            get
            {
                if (_tasksRepository == null)
                    _tasksRepository = new TasksRepository(_context);
                return _tasksRepository;
            }
        }
        
        
        public ICheckListRepository CheckListRepository
        {
            get
            {
                if (_checklistRepository == null)
                    _checklistRepository = new CheckListRepository(_context);
                return _checklistRepository;
            }
        }


        public void Dispose()
        {
            _context.Dispose();
            GC.SuppressFinalize(this);
        }

        public async Task<int> Save()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
