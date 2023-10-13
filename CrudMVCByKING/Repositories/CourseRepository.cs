using AutoMapper;
using CloudinaryDotNet.Actions;
using CrudMVCByKING.Data;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services;
using CrudMVCByKING.Services.Repository;
using Microsoft.EntityFrameworkCore;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace CrudMVCByKING.Repositories
{
    public class CourseRepository : ICourse
    {

        private readonly IMapper _mapper;
        private readonly UsersDbContext _context;
        private readonly IPhotoService _photoService;

        public CourseRepository(UsersDbContext context, IMapper mapper, IPhotoService photoService)
        {
            _context = context;
            _mapper = mapper;
            _photoService = photoService;
        }
       
        public async Task<Courses> Delete(Guid id)
        {
            var entity = await _context.Set<Courses>().FindAsync(id) ?? throw new Exception("Not found");
            _context.Set<Courses>().Remove(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<Courses?> Get(Guid id)
        {
            var entity = await _context.Set<Courses>().FindAsync(id) ?? throw new Exception("Not found");
            return entity;
        }

        public async Task<List<Courses>> GetAll()
        {
            var entities = await _context.Set<Courses>().ToListAsync();
            return entities;
        }



        public async Task<CoursesDto> Update(CoursesDto dto)
        {
            var course = await _context.Courses.FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (course == null)
            {
                throw new Exception("Course not found");
            }
            _context.Entry(course).State = EntityState.Detached;
            var entity = _mapper.Map<Courses>(dto) ?? throw new Exception("Not found");
            
            if (dto.Image == null)
            {
                entity.Image = course.Image;
            }
            else
            {
                var imageResult = await _photoService.AddPhotoAsync(dto.Image);
                entity.Image = imageResult.Url.ToString();

            }
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return _mapper.Map<CoursesDto>(entity);
        }


        public async Task<CoursesDto> Add(CoursesDto entity)
        {
            var imageResult = await _photoService.AddPhotoAsync(entity.Image);
            var entities = _mapper.Map<Courses>(entity);
            entities.Id = new Guid();
            if (imageResult != null)
            {
                entities.Image = imageResult.Url.ToString();
            }
            else
            {
                // Use a default value for the entities.Image property in case the imageResult object is null.
                entities.Image = "";
            }
            _context.Set<Courses>().Add(entities);
            await _context.SaveChangesAsync();
            return _mapper.Map<CoursesDto>(entities);
        }

      
    }
}
