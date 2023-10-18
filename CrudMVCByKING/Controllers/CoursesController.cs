using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Validations;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;

namespace CrudMVCByKING.Controllers
{
    public class CoursesController :  Controller
    {
        private readonly ICourse _repositoryService;
        private readonly IPhotoService _photoService;
        private readonly IToastNotification _toastNotification;
        private readonly UserManager<ApplicationUser> _userManager;

        public CoursesController(ICourse repositoryService, IPhotoService photoService, IToastNotification toastNotification, UserManager<ApplicationUser> userManager)
        {
            _repositoryService = repositoryService;
            _photoService = photoService;
            _toastNotification = toastNotification;
            _userManager = userManager;
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
                var validator = new CourseValidator();
                var validationResult = await validator.ValidateAsync(data);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        _toastNotification.AddErrorToastMessage(error.ErrorMessage);
                    }
                    return View(data);
                }

               var user = await _userManager.GetUserAsync(HttpContext.User);
                var course =    await _repositoryService.Add(data);
                await _repositoryService.CreateAudit(course, "Create", user);

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

                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _repositoryService.CreateAudit(data, "Edit", user);
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
                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _repositoryService.CreateAudit(data, "Delete", user);
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }
    }
}
