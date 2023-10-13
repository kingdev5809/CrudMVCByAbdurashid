using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models
{
    public class About : IEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [RegularExpression(@"\S", ErrorMessage = "Image cannot contain only spaces")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"\S", ErrorMessage = "Description cannot contain only spaces")]
        public string  Desc { get; set; }

    }

}
