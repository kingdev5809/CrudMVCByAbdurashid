using AutoMapper;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CrudMVCByKING.Data;

namespace CrudMVCByKING.Repositories
{
    public class LessonsRepository : ILessons

    {
        private readonly IMapper _mapper;
        private readonly UsersDbContext _context;
        public LessonsRepository(UsersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<LessonsDto> Add(LessonsDto entity)
        {
            var entities = _mapper.Map<Lessons>(entity);
            entities.Id = new Guid();

            _context.Set<Lessons>().Add(entities);
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonsDto>(entities);
        }

        public async Task<LessonsDto> Delete(Guid id)
        {
            var entity = await _context.Set<Lessons>().FindAsync(id) ?? throw new Exception("Not found");
            _context.Set<Lessons>().Remove(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonsDto>(entity);
        }

        public async Task<LessonsDto?> Get(Guid id)
        {
            var entity = await _context.Set<Lessons>().FindAsync(id) ?? throw new Exception("Not found");
            var dto = _mapper.Map<LessonsDto>(entity);
            return dto;
        }

        public async Task<List<Lessons>> GetAll()
        {
            var entities = await _context.Set<Lessons>().Include(l => l.Course).ToListAsync();
            return entities;
        }


        public async Task<LessonsDto> Update(LessonsDto dto)
        {
            var entity = _mapper.Map<Lessons>(dto) ?? throw new Exception("Not found");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<LessonsDto>(entity);
        }
    }
}
