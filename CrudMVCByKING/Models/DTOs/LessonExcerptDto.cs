namespace CrudMVCByKING.Models.DTOs
{
    public class LessonExcerptDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Video { get; set; }
        public Guid CourseId { get; set; }
    }
}
