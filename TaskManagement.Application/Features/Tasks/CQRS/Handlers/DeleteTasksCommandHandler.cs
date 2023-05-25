using System.Reflection.Metadata;
using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;
using TaskManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Tasks.CQRS.Handlers
{
    public class DeleteTasksCommandHandler : IRequestHandler<DeleteTasksCommand,Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteTasksCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(DeleteTasksCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var task = await _unitOfWork.TasksRepository.Get(request.Id);

            if (task == null)
            {
                response.Success = false ;
                response.Message = "Failed to Delete";
            }
            else
            {
                await _unitOfWork.TasksRepository.Delete(task);
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
