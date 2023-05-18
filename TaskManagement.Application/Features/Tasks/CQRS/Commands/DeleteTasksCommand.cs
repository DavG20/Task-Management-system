using MediatR;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Tasks.CQRS.Commands
{
    public class DeleteTasksCommand : IRequest<Result<Unit>>
    {
        
        public int Id { get; set; }

    }
}