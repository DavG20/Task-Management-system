using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Tasks.CQRS.Queries
{
    public class GetTasksListQuery : IRequest<Result<List<TasksDto>>>
    {
        
    }
}