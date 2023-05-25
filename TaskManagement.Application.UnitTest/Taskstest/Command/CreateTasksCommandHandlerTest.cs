using AutoMapper;
using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.Features.Tasks.CQRS.Commands;
using TaskManagement.Application.Features.Tasks.CQRS.Handlers;
using TaskManagement.Application.Features.Tasks.DTOs;
using TaskManagement.Application.Profiles;
using TaskManagement.Application.Responses;
using TaskManagement.Application.UnitTest.Mocks;

using MediatR;
using Moq;
using Shouldly;
using Xunit;

namespace TaskManagement.Application.UnitTest.Tasks.Commands
{
    public class CreateTasksCommandHandlerTest
    {

        private readonly IMapper _mapper;
        private readonly Mock<IUnitOfWork> _mockRepo;
        private readonly CreateTasksDto _TasksDto;
        private readonly CreateTasksCommandHandler _handler;
        public CreateTasksCommandHandlerTest()
        {
            _mockRepo = MockUnitOfWork.GetUnitOfWork();
            var mapperConfig = new MapperConfiguration(c =>
            {
                c.AddProfile<MappingProfile>();
            });
            _mapper = mapperConfig.CreateMapper();

            _TasksDto = new CreateTasksDto
            {
                Title = "title",
                Description = "Sample Content",
                Completed = true,
                StartDate = DateTime.Now.Date.AddMinutes(1),
                EndDate = DateTime.Now.Date.AddHours(2),
                UserId = 1
        };

            _handler = new CreateTasksCommandHandler(_mockRepo.Object, _mapper);

        }


        [Fact]
        public async Task CreateTasks()
        {
            var result = await _handler.Handle(new CreateTasksCommand() { CreateTasksDto = _TasksDto }, CancellationToken.None);
            result.ShouldBeOfType<Result<int>>();
            // result.Errors.ShouldContain("Start Date must be greater than or equal to the current date.");
            result.Success.ShouldBeTrue();
            var tasks = await _mockRepo.Object.TasksRepository.GetAll();
            tasks.Count.ShouldBe(3);

        }

        [Fact]
        public async Task CreateTasks_InvalidStartDate_FailsValidation()
        {
            // Arrange
            _TasksDto.StartDate = DateTime.Now.Date.AddDays(-1); // Set an invalid start date (before the current date)

            // Act
            var result = await _handler.Handle(new CreateTasksCommand() { CreateTasksDto = _TasksDto }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldContain("Start Date must be greater than or equal to the current date.");
            var tasks = await _mockRepo.Object.TasksRepository.GetAll();
            tasks.Count.ShouldBe(2); // The Tasks should not be created
        }


        [Fact]
        public async Task CreateTasks_InvalidEndDate_FailsValidation()
        {
            // Arrange
            _TasksDto.EndDate = DateTime.Now.Date.AddDays(-1); // Set an invalid end date (before the start date)

            // Act
            var result = await _handler.Handle(new CreateTasksCommand() { CreateTasksDto = _TasksDto }, CancellationToken.None);

            // Assert
            result.ShouldBeOfType<Result<int>>();
            result.Success.ShouldBeFalse();
            result.Errors.ShouldContain("End Date must be greater than or equal to the Start Date.");
            var tasks = await _mockRepo.Object.TasksRepository.GetAll();
            tasks.Count.ShouldBe(2); // The Tasks should not be created
        }
       
    }
}