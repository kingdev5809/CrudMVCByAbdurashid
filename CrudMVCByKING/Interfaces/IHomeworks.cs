
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;

namespace CrudMVCByKING.Interfaces
{
    public interface IHomeworks
    {
        Task<List<Homeworks>> GetAll();
        Task<HomeworkDto?> Get(Guid id);
        Task<HomeworkDto> Add(HomeworkDto entity);
        Task<HomeworkDto> Update(HomeworkDto entity);
        Task<HomeworkDto> Delete(Guid id);
        Task<List<Lessons>> GetLessons();
    }
}
