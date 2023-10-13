using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class TeachersRepository : RepositoryService<Teachers, TeachersDto, UsersDbContext>
    {
        public TeachersRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
