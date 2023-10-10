using System.ComponentModel;

namespace CrudMVCByKING.Models.DTOs
{
    public class UserDto : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultValue("User")]
        public string Role { get; set; }
    }
    public class UserDTO : IEntity
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        [DefaultValue("User")]
        public string Role { get; set; }
        public List<CoursesDto> Courses { get; set; } = new List<CoursesDto>();
    }
    public class LoginDto : IEntityDto
    {
        public Guid Id { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
