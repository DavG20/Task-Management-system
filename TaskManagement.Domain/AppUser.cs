using System.ComponentModel.DataAnnotations;
using TaskManagement.Domain.Common;
using Microsoft.AspNetCore.Identity;


namespace TaskManagement.Domain
{
    public class AppUser : IdentityUser
    {
        public string UserName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        public string Password { get; set; }

    }
}