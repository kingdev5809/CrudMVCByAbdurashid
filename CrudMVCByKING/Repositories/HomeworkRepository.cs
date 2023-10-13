using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;
using Humanizer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CrudMVCByKING.Repositories
{
    public class HomeworkRepository : IHomeworks
    {
        private readonly IMapper _mapper;
        private readonly UsersDbContext _context;
        public HomeworkRepository(UsersDbContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;

        }

        public async Task<HomeworkDto> Add(HomeworkDto entity)
        {
            var entities = _mapper.Map<Homeworks>(entity);
            entities.Id = new Guid();
            _context.Set<Homeworks>().Add(entities);
            await _context.SaveChangesAsync();
            return _mapper.Map<HomeworkDto>(entities);
        }

        public async Task<HomeworkDto> Delete(Guid id)
        {
            var entity = await _context.Set<Homeworks>().FindAsync(id) ?? throw new Exception("Not found");
            _context.Set<Homeworks>().Remove(entity);
            await _context.SaveChangesAsync();
            return _mapper.Map<HomeworkDto>(entity);
        }

        public async Task<HomeworkDto?> Get(Guid id)
        {
            var entity = await _context.Set<Homeworks>().FindAsync(id) ?? throw new Exception("Not found");
            var dto = _mapper.Map<HomeworkDto>(entity);
            return dto;
        }

        public async Task<List<Homeworks>> GetAll()
        {
            var entities = await _context.Set<Homeworks>().Include(l => l.Lesson).ToListAsync();
            return entities;
        }

      

        public async Task<HomeworkDto> Update(HomeworkDto dto)
        {
            var entity = _mapper.Map<Homeworks>(dto) ?? throw new Exception("Not found");
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<HomeworkDto>(entity);
        }

        public async Task<List<Lessons>> GetLessons()
        {
           var lessons = await _context.Lessons.ToListAsync();
            return lessons;
        }
    }
}
