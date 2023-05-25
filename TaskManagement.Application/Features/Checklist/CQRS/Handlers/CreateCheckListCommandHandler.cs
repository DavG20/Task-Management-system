using TaskManagement.Domain;
using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Checklist.CQRS.Commands;
using TaskManagement.Application.Features.Checklist.DTOs.Validators;
using TaskManagement.Application.Responses;
using MediatR;

namespace TaskManagement.Application.Features.Checklist.CQRS.Handlers
{
    public class CreateCheckListCommandHandler : IRequestHandler<CreateCheckListCommand, Result<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateCheckListCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<int>> Handle(CreateCheckListCommand request, CancellationToken cancellationToken)
        {
            var response = new Result<int>();
            var validator = new CreateCheckListDtoValidator();
            var validationResult = await validator.ValidateAsync(request.CreateCheckListDto);

            if (validationResult.IsValid == false)
            {
                response.Success = false;
                response.Message = "Validation Error";
                response.Errors = validationResult.Errors.Select(q => q.ErrorMessage).ToList();
            }
            else
            {
                var checkList = _mapper.Map<CheckList>(request.CreateCheckListDto);

                checkList = await _unitOfWork.CheckListRepository.Add(checkList);
                if (await _unitOfWork.Save() > 0)
                {
                    response.Success = true;
                    response.Message = "Creation Successful";
                    response.Value = checkList.Id;
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
