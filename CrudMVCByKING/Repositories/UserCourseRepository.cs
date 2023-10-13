using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Data;

namespace CrudMVCByKING.Repositories
{
    public class UserCourseRepository : IUserCourse
    {
        private readonly UsersDbContext _context;
        public UserCourseRepository(UsersDbContext context)
        {
            _context = context;
        }

        public async Task<List<UserCourses>> AddUserCourse(Guid UserId, Guid CourseId)
        {
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Id == UserId);
            var course = await _context.Courses.FirstOrDefaultAsync(u => u.Id == CourseId);
            var userCourses = new UserCourses
            {
                UserId = UserId,
                CourseId = CourseId,
            };

            if (user == null)
            {
                throw new Exception("User not found ");
            }
            if (course == null)
            {
                throw new Exception("Course not found ");

            }
            var userCourseExist =  _context.UserCourses.Any(pt => pt.UserId == UserId && pt.CourseId == CourseId);
            if (userCourseExist)
            {
                throw new Exception("The Course already exists in User.");
            }
            _context.UserCourses.Add(userCourses);
            await _context.SaveChangesAsync();
            return null;
        }

        
        public async Task<List<UserCourses>> DeleteUserCourses(Guid UserId, Guid CourseId)
        {
            var userCourseDelete = _context.UserCourses.FirstOrDefaultAsync(pt => pt.UserId == UserId && pt.CourseId == CourseId);
            if (userCourseDelete == null)
            {
                throw new Exception("User Course not found");
            }
            _context.UserCourses.Remove(await userCourseDelete);
            await _context.SaveChangesAsync();
            return null;
        }

        public async Task<List<UserCourses>> GetAllUserCourses()
        {
            var userCourses = await _context.UserCourses.ToListAsync();
            return userCourses;
        }
    }
}
