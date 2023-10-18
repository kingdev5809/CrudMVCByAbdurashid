using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Controllers
{
    public class ContactController : AppDbController<ContactDto, ContactRepository>
    {
        public ContactController(IRepositoryService<ContactDto> repository, UserManager<ApplicationUser> userManager) : base(repository, userManager)
        {
        }
    }
}
