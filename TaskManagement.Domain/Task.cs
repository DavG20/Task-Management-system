
using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class Task : BaseDomainEntity
    {

        public string Title { get; set; }

        public string Description { get; set; }

        public string UserId { get; set; }
        public AppUser User { get; set; }
        public bool Completed { get; set; }

        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public ICollection<CheckList> CheckLists { get; set; }

    }
}
