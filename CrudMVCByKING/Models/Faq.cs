namespace CrudMVCByKING.Models
{
    public class Faq : IEntity
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Descr { get; set; }
        public int CourseId { get; set; }
    }
}
