
using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{ 
    public class Tasks : BaseDomainEntity
    {
        
        public string Title { get; set; }

        public int UserId { get; set; }
        public string Description { get; set; }

        public bool Completed { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

    }
}
