using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class ResultRepository : RepositoryService<Result, ResultDto, UsersDbContext>
    {
        public ResultRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
