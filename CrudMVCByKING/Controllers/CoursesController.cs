using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Repositories;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCByKING.Controllers
{
    public class CoursesController :  Controller
    {
        private readonly ICourse _repositoryService;
        private readonly IPhotoService _photoService;
        public CoursesController(ICourse repositoryService, IPhotoService photoService)
        {
            _repositoryService = repositoryService;
            _photoService = photoService;
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
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(CoursesDto data)
        {
            try
            {
                await _repositoryService.Add(data);

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
            
                if (data == null) return NotFound();
                return View(data);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConiform(Guid id, CoursesDto data)
        {
            try
            {
                var updatedData = await _repositoryService.Update(data);
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
