using MediatR;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Checklist.CQRS.Commands
{
    public class DeleteCheckListCommand : IRequest<Result<Unit>>
    {

        public int Id { get; set; }
        
    }
}