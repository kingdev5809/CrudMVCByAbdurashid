using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Models;

namespace CrudMVCByKING.Interfaces
{
    public interface ICourse
    {
        Task<List<Courses>> GetAll();
        Task<Courses?> Get(Guid id);
        Task<CoursesDto> Add(CoursesDto entity);
        Task<CoursesDto> Update(CoursesDto entity);
        Task<Courses> Delete(Guid id);

    }
}
