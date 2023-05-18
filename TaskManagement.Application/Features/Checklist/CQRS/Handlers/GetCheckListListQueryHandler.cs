using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Features.Checklist.CQRS.Queries;
using TaskManagement.Application.Responses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.Features.Checklist.CQRS.Handlers
{
    public class GetCheckListListQueryHandler : IRequestHandler<GetCheckListListQuery, Result<List<CheckListDto>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetCheckListListQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<List<CheckListDto>>> Handle(GetCheckListListQuery request, CancellationToken cancellationToken)
        {

            var response = new Result<List<CheckListDto>>();
            var checkList = await _unitOfWork.CheckListRepository.GetAll();
       
            response.Success = true;
            response.Message = "Fetch Success";
            response.Value = _mapper.Map<List<CheckListDto>>(checkList);

            return response;
        }
    }
}
