using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models
{
    public class Contact : IEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"\S", ErrorMessage = "Description cannot contain only spaces")]
        public string Name { get; set; }
        public int? Number { get; set; }
        public int? WhenCall { get; set; }
        public Guid? UserId{ get; set;}
    }
}
