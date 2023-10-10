using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Controllers
{
    public class TeachersController : AppDbController<TeachersDto, TeachersRepository>
    {
        public TeachersController(IRepositoryService<TeachersDto> repository) : base(repository)
        {
        }
    }
}
