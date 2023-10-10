using AutoMapper;
using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Models;

namespace CrudMVCByKING.Services.Repository
{
    public class RepositoryService<TEntity, TDto, TContext> : IRepositoryService<TDto>
          where TEntity : class, IEntity
          where TDto : class, IEntityDto
          where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly IMapper _mapper;
        public RepositoryService(TContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;   
        }
        public async Task<List<TDto>> GetAll()
        {
            var entities = await _context.Set<TEntity>().ToListAsync();
            var dtos =  _mapper.Map<List<TDto>>(entities);
            return dtos;
        }
        public async Task<TDto?> Get(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id) ?? throw new Exception("Not found");
            var dto = _mapper.Map<TDto>(entity);
            return dto;
        }
        public async Task<TDto> Add(TDto dto)
        {
            var entity =  _mapper.Map<TEntity>(dto);
            entity.Id = new Guid();
            _context.Set<TEntity>().Add(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(entity); 
        }
        public async Task<TDto> Update(TDto dto)
        {
            var entity = _mapper.Map<TEntity>(dto) ?? throw new Exception("Not found");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
        public async Task<TDto> Delete(Guid id)
        {
            var entity = await _context.Set<TEntity>().FindAsync(id) ?? throw new Exception("Not found");
            _context.Set<TEntity>().Remove(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<TDto>(entity);
        }
    }
}
