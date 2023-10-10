using System.ComponentModel.DataAnnotations.Schema;

namespace CrudMVCByKING.Models
{
    public class UserCourses : IEntity2
    {

        public Guid  UserId { get; set; }
  
        public Users? User { get; set; } 


        public Guid CourseId { get; set; }
        public Courses? Course { get; set; } = null!;
    }
}
