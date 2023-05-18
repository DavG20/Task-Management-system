using MediatR;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Tasks.CQRS.Commands
{
    public class CreateTasksCommand : IRequest<Result<int>>
    {
        public CreateTasksDto CreateTasksDto { get; set; }
        
    }
}