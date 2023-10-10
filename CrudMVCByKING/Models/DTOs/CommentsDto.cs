namespace CrudMVCByKING.Models.DTOs
{
    public class CommentsDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string? Desc { get; set; }
        public string? UserName { get; set; }
        public Guid PostId { get; set; }
        public Guid CourseId { get; set; }
    }
}
