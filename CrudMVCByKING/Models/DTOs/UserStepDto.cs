namespace CrudMVCByKING.Models.DTOs
{
    public class UserStepDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string? Progress { get; set; }
        public string? Completed { get; set; }
        public string? notCompleted { get; set; }
        public int? userId { get; set; }
        public int? homeworkId { get; set; }
    }
}
