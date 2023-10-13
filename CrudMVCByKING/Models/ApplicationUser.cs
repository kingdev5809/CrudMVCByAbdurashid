using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Models
{
    public class ApplicationUser : IdentityUser
    {        
        public string Role { get; set; } = "User";
    }
}
