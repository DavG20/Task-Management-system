using TaskManagement.Application.Features.Common;

namespace TaskManagement.Application.Features.Checklist.DTOs
{
    public class UpdateCheckListDto :BaseDto, ICheckListDto
    {
        
        public string Title { get; set; }

        
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}