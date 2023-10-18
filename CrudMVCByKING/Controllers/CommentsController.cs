using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;

namespace CrudMVCByKING.Controllers
{
    public class CommentsController : AppDbController<CommentsDto, CommentsRepository>
    {
        public CommentsController(IRepositoryService<CommentsDto> repository, UserManager<ApplicationUser> userManager) : base(repository, userManager)
        {
        }
    }
}
