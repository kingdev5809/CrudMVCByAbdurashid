using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCByKING.Controllers
{
    public class AboutController : AppDbController<AboutDto, AboutRepository>
    {
        public AboutController(IRepositoryService<AboutDto> repository, UserManager<ApplicationUser> userManager) : base(repository, userManager)
        {
        }
    }
}
