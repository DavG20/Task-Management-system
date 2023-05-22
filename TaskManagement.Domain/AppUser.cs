using System.ComponentModel.DataAnnotations;
using doman =TaskManagement.Domain;
using Microsoft.AspNetCore.Identity;


namespace TaskManagement.Domain
{
    public class AppUser : IdentityUser
    {

        public virtual ICollection<doman.Task> Tasks { get; set; }




    }
}