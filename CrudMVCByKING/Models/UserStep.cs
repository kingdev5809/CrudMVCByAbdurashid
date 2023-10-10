namespace CrudMVCByKING.Models
{
    public class UserStep
    {
        public int Id { get; set; }
        public string? Progress { get; set; }
        public string? Completed { get; set; }
        public string? notCompleted { get; set; }
        public int? userId { get; set; }
        public int? homeworkId { get; set; }

    }
}
