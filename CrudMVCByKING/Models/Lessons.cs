using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;

namespace CrudMVCByKING.Models
{
    public class Lessons : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string  Desc { get; set; }
        public string  Video { get; set; }
        public Guid CourseId { get; set; }
        public Courses Course{ get; set; }
        public ICollection<Homeworks> Homeworks { get; set; }

    }

    public class LessonCreateViewModel
    {
        public LessonsDto Lesson { get; set; }
        public List<Courses> Courses { get; set; }
    }
}
