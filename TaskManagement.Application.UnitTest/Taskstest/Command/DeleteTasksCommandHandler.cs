using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Tasks.CQRS.Handlers;
using TaskManagement.Application.Profiles;
using TaskManagement.Application.Responses;
using TaskManagement.Application.UnitTest.Mocks;
using MediatR;
using Moq;
using Shouldly;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;

namespace TaskManagement.Application.UnitTest.Tasks.Commands
{

    public class DeleteTasksCommandHandlerTest
    {
        private readonly IMapper _mapper;

        private readonly Mock<IUnitOfWork> _mockRepo;
        private int _id { get; set; }
        private readonly DeleteTasksCommandHandler _handler;
        public DeleteTasksCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
          
            _id = 1;

            _mapper = mapperConfig.CreateMapper();
            _handler = new DeleteTasksCommandHandler(_mockRepo.Object , _mapper);

        }


        [Fact]
        public async Task DeleteTask()
        {

            var result = await _handler.Handle(new DeleteTasksCommand() { Id = _id }, CancellationToken.None);
            var tasks = await _mockRepo.Object.TasksRepository.GetAll();

            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeTrue();

            tasks = await _mockRepo.Object.TasksRepository.GetAll();
            tasks.Count().ShouldBe(1);
        }

        [Fact]
        public async Task Delete_Task_Doesnt_Exist()
        {

            _id  = 0;
            var result = await _handler.Handle(new DeleteTasksCommand() { Id = _id }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            var tasks = await _mockRepo.Object.TasksRepository.GetAll();
            tasks.Count.ShouldBe(2);

        }
    }
}


