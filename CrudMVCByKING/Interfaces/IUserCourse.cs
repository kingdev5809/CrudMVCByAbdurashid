using CrudMVCByKING.Models;

namespace CrudMVCByKING.Interfaces
{
    public interface IUserCourse
    {
        Task<List<UserCourses>> AddUserCourse(Guid UserId, Guid CourseId);
        Task<List<UserCourses>> DeleteUserCourses(Guid UserId, Guid CourseId);
        Task<List<UserCourses>> GetAllUserCourses();
    }
}
