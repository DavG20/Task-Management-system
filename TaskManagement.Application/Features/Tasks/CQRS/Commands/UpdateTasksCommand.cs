using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Tasks.CQRS.Commands
{
    public class UpdateTasksCommand :IRequest<Result<Unit>>
    {
        public UpdateTasksDto UpdateTasksDto { get; set; }
        
    }
}