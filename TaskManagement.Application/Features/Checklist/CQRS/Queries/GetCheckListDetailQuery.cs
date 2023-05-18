using MediatR;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Responses;

namespace TaskManagement.Application.Features.Checklist.CQRS.Queries
{
    public class GetCheckListDetailQuery : IRequest<Result<CheckListDto>>
    {
        public int Id { get; set; }
        
    }
}