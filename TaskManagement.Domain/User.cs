using TaskManagement.Domain.Common;

namespace TaskManagement.Domain
{
    public class User : BaseDomainEntity
    {
        public string FullName { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }
        
    }
}