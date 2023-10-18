using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Controllers
{
    public class ResultController : AppDbController<ResultDto, ResultRepository>
    {
        public ResultController(IRepositoryService<ResultDto> repository, UserManager<ApplicationUser> userManager) : base(repository, userManager)
        {
        }
    }
}
