namespace CrudMVCByKING.Models
{
    public class About : IEntity
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string  Desc { get; set; }

    }

}
