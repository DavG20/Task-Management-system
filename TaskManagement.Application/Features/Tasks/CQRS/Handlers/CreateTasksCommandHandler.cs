using tasksDomain = TaskManagement.Domain;
using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;
using TaskManagement.Application.Features.Tasks.DTOs.Validators;
using TaskManagement.Application.Responses;
using MediatR;

namespace TaskManagement.Application.Features.Tasks.CQRS.Handlers
{
    public class CreateTasksCommandHandler : IRequestHandler<CreateTasksCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateTasksCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateTasksCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateTasksDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateTasksDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var tasks = _mapper.Map<tasksDomain.Task>(request.CreateTasksDto);

                tasks = await _unitOfWork.TasksRepository.Add(tasks);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = tasks.Id;
                }
                else
                {
                    response.Success = false;
                    response.Message = "Creation Failed";
                }
            }

            return response;
        }
    }
}
