using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models
{
    public class Result : IEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"\S", ErrorMessage = "Title cannot contain only spaces")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"\S", ErrorMessage = "Description cannot contain only spaces")]
        public string Desc { get; set; }
        [Required(ErrorMessage = "Image is required")]
        [RegularExpression(@"\S", ErrorMessage = "Image cannot contain only spaces")]
        public string Image { get; set; }
        [Required(ErrorMessage = "User name is required")]
        [RegularExpression(@"\S", ErrorMessage = "User name cannot contain only spaces")]
        public string UserName { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

    }
}
