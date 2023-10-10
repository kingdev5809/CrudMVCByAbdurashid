using CrudMVCByKING.Models.DTOs;

namespace CrudMVCByKING.Models
{
    public class Homeworks : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public int  UserId { get; set; }
        public string Desc { get; set; }
        public Guid LessonId { get; set; }
        public  Lessons Lesson{ get; set; }
    }

    public class HomeworkViewModel
    {
        public HomeworkDto Homework { get; set; }
        public List<Lessons> Lessons { get; set; }
    }

}
