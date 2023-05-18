using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class CheckList : BaseDomainEntity
    {
        
        public string Title { get; set; }

        public int TasksId { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }
    }
}