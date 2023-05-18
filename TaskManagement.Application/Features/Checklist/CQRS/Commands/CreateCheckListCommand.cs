using MediatR;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Checklist.CQRS.Commands
{
    public class CreateCheckListCommand : IRequest<Result<int>>
    {
        public CreateCheckListDto CreateCheckListDto { get; set; }
    }
}