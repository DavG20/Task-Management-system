namespace TaskManagement.Application.Features.Checklist.DTOs
{
    public interface ICheckListDto
    {
        public string Title { get; set; }

        public string Description { get; set; }

        public bool Completed { get; set; }

        
    }
}