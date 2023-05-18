namespace TaskManagement.Application.Contracts.Persistence
{
    public interface IUnitOfWork : IDisposable
    {
        ITasksRepository TasksRepository{get;}
        ICheckListRepository CheckListRepository{get;}

        Task<int> Save();
         
    }
}