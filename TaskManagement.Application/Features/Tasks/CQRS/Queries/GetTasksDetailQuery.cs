using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Tasks.CQRS
{

   public class GetTasksDetailQuery :IRequest<Result<TasksDto>>
    {
        
        public int Id { get; set; }
    }
    
}