using TaskManagement.Application.Features.Common;

namespace TaskManagement.Application.Features.Tasks.DTOs
{
    public class UpdateTasksDto :BaseDto , ITasksDto
    {
         public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}