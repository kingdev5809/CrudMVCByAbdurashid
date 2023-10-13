namespace CrudMVCByKING.Models.DTOs
{
    public class CoursesDto : IEntityDto
    {
        public Guid Id { get; set; }
        public IFormFile? Image { get; set; }
        public string? Title { get; set; }
        public string? Desc { get; set; }
        public int? Price { get; set; }
    }
}
