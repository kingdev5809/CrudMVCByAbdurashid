namespace CrudMVCByKING.Models;

public interface IEntity
{
    Guid Id { get; set; }   

}

public interface IEntity2
{
    Guid UserId { get; set; }
    Guid CourseId { get; set; }
}