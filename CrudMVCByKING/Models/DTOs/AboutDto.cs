namespace CrudMVCByKING.Models.DTOs
{
    public class AboutDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Image { get; set; }
        public string Desc { get; set; }
    }
}
