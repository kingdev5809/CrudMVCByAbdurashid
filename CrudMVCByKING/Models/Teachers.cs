namespace CrudMVCByKING.Models
{
    public class Teachers : IEntity
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Title { get; set; }
        public string Desc { get; set; }

    }
}
