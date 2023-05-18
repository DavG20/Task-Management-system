namespace TaskManagement.Application.Features.Checklist.DTOs
{
    public class CreateCheckListDto : ICheckListDto
    {
        public string Title { get; set; }

        public int TasksId { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }

        
    }
}