using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Exceptions;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;
using TaskManagement.Application.Features.Tasks.DTOs.Validators;
using TaskManagement.Application.Responses;
using MediatR;

namespace TaskManagement.Application.Features.Tasks.CQRS.Handlers
{
    public class UpdateTasksCommandHandler : IRequestHandler<UpdateTasksCommand, Result<Unit>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateTasksCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<Unit>> Handle(UpdateTasksCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<Unit>();

            var validator = new UpdateTasksDtoValidator();
            var validationResult = await validator.ValidateAsync(request.UpdateTasksDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Update Failed";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var tasks = await _unitOfWork.TasksRepository.Get(request.UpdateTasksDto.Id);

                if (tasks == null)
                    return null;
                   
                _mapper.Map(request.UpdateTasksDto, tasks);

                await _unitOfWork.TasksRepository.Update(tasks);
              
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Updated Successful";
                    
                }
                else
                {
                    response.Success = false;
                    response.Message = "Update Failed";
                }    
            }

            return response;
        }
    }
}
