using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class CommentsRepository : RepositoryService<Comments, CommentsDto, UsersDbContext>
    {
        public CommentsRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
