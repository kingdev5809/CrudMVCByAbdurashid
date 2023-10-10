namespace CrudMVCByKING.Models.DTOs
{
    public class HomeworkDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public Guid LessonId { get; set; }
    }
 
}
