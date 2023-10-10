using Microsoft.AspNetCore.Authorization;

using CrudMVCByKING.Models.DTOs;

using CrudMVCByKING.Interfaces;

using CrudMVCByKING.Models;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCByKING.Controllers
{
    [Authorize]
    public class HomeworksController : Controller
    {
        private readonly IHomeworks _repositoryService;

        public HomeworksController( IHomeworks repository)
        {
            _repositoryService = repository;            
        }

        public async Task<IActionResult> Index()
        {
            var data = await _repositoryService.GetAll();

            return View(data);
        }



        public async Task<IActionResult> Details(Guid id)
        {
            try
            {
                var data = await _repositoryService.Get(id);
                if (data == null) return NotFound();
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }



        public async Task<IActionResult> Create()
        {
            var homeworkViewModel = new HomeworkViewModel();
            homeworkViewModel.Homework = new HomeworkDto();
            homeworkViewModel.Lessons = await _repositoryService.GetLessons();
            return View(homeworkViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(HomeworkViewModel data)
        {
            try
            {
                await _repositoryService.Add(data.Homework);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        public async Task<IActionResult> Edit(Guid id)
        {
            try
            {

                var data = await _repositoryService.Get(id);
                var homeworkViewModel = new HomeworkViewModel();
                homeworkViewModel.Homework = data;
                homeworkViewModel.Lessons = await _repositoryService.GetLessons();
                if (data == null) return NotFound();
                return View(homeworkViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConiform(Guid id, HomeworkViewModel data)
        {
            try
            {
                var updatedData = await _repositoryService.Update(data.Homework);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }



        public async Task<IActionResult> Delete(Guid id)
        {
            try
            {
                var data = await _repositoryService.Get(id);
                if (data == null) return NotFound();
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }



        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            try
            {
                var data = await _repositoryService.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
