using AutoMapper;
using CrudMVCByKING.Data;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Repositories
{
    public class ContactRepository : RepositoryService<Contact, ContactDto, UsersDbContext>
    {
        public ContactRepository(UsersDbContext context, IMapper mapper) : base(context, mapper)
        {

        }
    }
}
