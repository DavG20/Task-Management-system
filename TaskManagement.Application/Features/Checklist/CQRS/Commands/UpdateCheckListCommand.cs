using MediatR;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Checklist.CQRS.Commands
{
    public class UpdateCheckListCommand : IRequest<Result<Unit>>
    {

        public UpdateCheckListDto UpdateCheckListDto { get; set; }
        
    }
}