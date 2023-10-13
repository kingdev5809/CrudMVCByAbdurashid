using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class LessonExpRepository : RepositoryService<LessonExcerpt, LessonExcerptDto, UsersDbContext>
    {
        public LessonExpRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
