using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models
{
    public class Faq : IEntity
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "Title is required")]
        [RegularExpression(@"\S", ErrorMessage = "Title cannot contain only spaces")]
        public string Title { get; set; }
        [Required(ErrorMessage = "Description is required")]
        [RegularExpression(@"\S", ErrorMessage = "Description cannot contain only spaces")]
        public string Descr { get; set; }

        public int CourseId { get; set; }
    }
}
