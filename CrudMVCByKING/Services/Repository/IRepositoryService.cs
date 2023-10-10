using CrudMVCByKING.Models;

namespace CrudMVCByKING.Services.Repository
{
    public interface IRepositoryService<TDto> where TDto : class, IEntityDto
    {
        Task<List<TDto>> GetAll();
        Task<TDto?> Get(Guid id);
        Task<TDto> Add(TDto entity);
        Task<TDto> Update(TDto entity);
        Task<TDto> Delete(Guid id);
    }

}
