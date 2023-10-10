using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;

namespace CrudMVCByKING.Controllers
{
    public class ResultController : AppDbController<ResultDto, ResultRepository>
    {
        public ResultController(IRepositoryService<ResultDto> repository) : base(repository)
        {
        }
    }
}
