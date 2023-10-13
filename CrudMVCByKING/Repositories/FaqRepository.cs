using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class FaqRepository : RepositoryService<Faq,FaqDto, UsersDbContext>
    {
        public FaqRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {
        }
    }
}
