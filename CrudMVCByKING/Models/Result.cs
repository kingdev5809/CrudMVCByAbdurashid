namespace CrudMVCByKING.Models
{
    public class Result : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }
        public string Image { get; set; }
        public string UserName { get; set; }
        public Guid CourseId { get; set; }
        public Guid UserId { get; set; }

    }
}
