using CrudMVCByKING.Models;

namespace CrudMVCByKING.Models.DTOs
{
    public class LessonsDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string  Desc { get; set; }
        public string  Video { get; set; }
        public Guid CourseId { get; set; }

    }
}
