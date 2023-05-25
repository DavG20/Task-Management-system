using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Checklist.CQRS.Commands;
using TaskManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace TaskManagement.Application.Features.Checklist.CQRS.Handlers
{
    public class DeleteCheckListCommandHandler : IRequestHandler<DeleteCheckListCommand,Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(DeleteCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();
            var checklist = await _unitOfWork.CheckListRepository.Get(request.Id);

            if (checklist == null)
            {
                return null;
            }
            else
            {
                await _unitOfWork.CheckListRepository.Delete(checklist);
                if (await _unitOfWork.Save() > 0 )
                {
                    response.Success = true;
                    response.Message = "Delete Successful";
                }
                else
                {
                    response.Success = false;
                    response.Message = "Delete Failed";
                }
            
            }
            return response;
        }
    }
}
