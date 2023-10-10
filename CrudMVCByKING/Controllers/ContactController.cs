using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Controllers
{
    public class ContactController : AppDbController<ContactDto, ContactRepository>
    {
        public ContactController(IRepositoryService<ContactDto> repository) : base(repository)
        {
        }
    }
}
