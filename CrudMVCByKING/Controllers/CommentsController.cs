using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Controllers
{
    public class CommentsController : AppDbController<CommentsDto, CommentsRepository>
    {
        public CommentsController(IRepositoryService<CommentsDto> repository) : base(repository)
        {
        }
    }
}
