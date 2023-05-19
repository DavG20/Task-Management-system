using TaskManagement.Application.Contracts.Persistence;
using TaskManagement.Application.UnitTest.Mocks;
using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TaskManagement.Application.UnitTest.Mocks
{
    public static class MockUnitOfWork
    {
        public static int changes = 0;
        public static Mock<IUnitOfWork> GetUnitOfWork()
        {   var mockUow = new Mock<IUnitOfWork>();
           

            var mockTasksRepo = MockTasksRepository.GetTasksRepository();

           

            mockUow.Setup(r => r.TasksRepository).Returns(mockTasksRepo.Object);

            mockUow.Setup(r => r.Save()).ReturnsAsync(() =>
            {
                var temp = changes;
                changes = 0;
                return temp;
            });

    
            

            return mockUow;

    }

     
}
}
