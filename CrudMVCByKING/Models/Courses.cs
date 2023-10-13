using CrudMVCByKING.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace CrudMVCByKING.Models;

public class Courses : IEntity
{
    public Guid Id { get; set; }
    public string? Image { get; set; }
    public string? Title { get; set; }
    public string? Desc { get; set; }
    public int? Price { get; set; }
    public List<Users>? Users { get; } = new();
    public ICollection<Lessons>? Lessons { get; set; }

}


public class Comments : IEntity
{
    public Guid Id { get; set; }
    public string? Desc { get; set; }
    public string? UserName { get; set; }
    public Guid? UserId { get; set; }
    public Users? Users { get; set; }
    public Guid PostId { get; set; }
    public Guid CourseId { get; set; }

}

public class LessonExcerpt : IEntity
{
    public Guid Id { get; set; }
    public string Video { get; set; }
    public Guid CourseId { get; set; }

}
