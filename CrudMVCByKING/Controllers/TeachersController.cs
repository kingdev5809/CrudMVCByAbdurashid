using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Controllers
{
    public class TeachersController : AppDbController<TeachersDto, TeachersRepository>
    {
        public TeachersController(IRepositoryService<TeachersDto> repository, UserManager<ApplicationUser> userManager) : base(repository, userManager)
        {
        }
    }
}
