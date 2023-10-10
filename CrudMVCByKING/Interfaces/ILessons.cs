using CrudMVCByKING.Models.DTOs;
using Microsoft.AspNetCore.Mvc;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Models;

namespace CrudMVCByKING.Interfaces
{
    public interface ILessons
    {
         Task<List<Lessons>> GetAll();
        Task<LessonsDto?> Get(Guid id);
        Task<LessonsDto> Add(LessonsDto entity);
        Task<LessonsDto> Update(LessonsDto entity);
        Task<LessonsDto> Delete(Guid id);
    }
}
