using TaskManagement.Domain;
namespace TaskManagement.Application.Contracts.Persistence

{
    public interface ITasksRepository : IGenericRepository<Domain.Task>
    {

    }
}