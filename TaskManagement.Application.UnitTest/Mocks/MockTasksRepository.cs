using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Domain;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities;
using Moq;
using TaskManagement.Application.UnitTest.Mocks;

namespace TaskManagement.Application.UnitTest.Mocks
{
    public static class MockTasksRepository
    {
        public static Mock<ITasksRepository> GetTasksRepository()
        {
            var tasks = new List<Domain.Task>
            {
                 new Domain.Task
                {
                    Title = "sample title",
                    Description = "Sample des",
                    Completed = false,
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddHours(2),
                    Id = 1,
                    UserId = "1"
                },

                new Domain.Task
                {
                    Title = "sample title ",
                    Description = "Sample des ",
                    Completed = false,
                    StartDate = DateTime.Now.Date,
                    EndDate = DateTime.Now.Date.AddHours(1),
                    Id = 2,
                    UserId = "2"
                }
            };

            var mockRepo = new Mock<ITasksRepository>();

            mockRepo.Setup(r => r.GetAll()).ReturnsAsync(tasks);

            mockRepo.Setup(r => r.Add(It.IsAny<Domain.Task>())).ReturnsAsync((Domain.Task task) =>
            {
                task.Id = tasks.Count() + 1;
                tasks.Add(task);
                MockUnitOfWork.changes += 1;
                return task;
            });

            mockRepo.Setup(r => r.Update(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
                var newTasks = tasks.Where((r) => r.Id != task.Id);
                tasks = newTasks.ToList();
                tasks.Add(task);
                MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Delete(It.IsAny<Domain.Task>())).Callback((Domain.Task task) =>
            {
                if (tasks.Remove(task))
                    MockUnitOfWork.changes += 1;
            });

            mockRepo.Setup(r => r.Get(It.IsAny<int>())).ReturnsAsync((int Id) =>
            {
                return tasks.FirstOrDefault((r) => r.Id == Id);
            });


            return mockRepo;

        }
    }
}