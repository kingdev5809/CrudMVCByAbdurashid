using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVCByKING.Models
{
    public class Users: IEntity
    {      
        public Guid Id { get; set; }
        public string? Name { get; set; }
        public string? Email{ get; set; }
        public string? Password { get; set; }
        [DefaultValue("User")]
        public string Role { get; set; } = "User";
        public List<Courses> Courses { get; } = new();
    }
}
