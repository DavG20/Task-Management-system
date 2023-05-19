using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Checklist.CQRS.Handlers;
using TaskManagement.Application.Features.Checklist.CQRS.Queries;
using TaskManagement.Application.Features.Checklist.DTOs;
using TaskManagement.Application.Profiles;
using TaskManagement.Application.Responses;
using TaskManagement.Application.UnitTest.Mocks;
using Moq;
using Shouldly;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.UnitTest.Checklist.Queries
{
    public class GetCheckListQueryHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly GetCheckListListQueryHandler _handler;
        public GetCheckListQueryHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _handler = new GetCheckListListQueryHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task GetCheckLists()
        {
            var result = await _handler.Handle(new GetCheckListListQuery(), CancellationToken.None);
            result.ShouldBeOfType<Result<List<CheckListDto>>>();
            result.Value.Count.ShouldBe(2);
        }
    }
}



