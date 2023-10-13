using CrudMVCByKING.Data;
using CrudMVCByKING.Interfaces;
using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using CrudMVCByKING.Validations;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using NToastNotify;

namespace CrudMVCByKING.Controllers
{

    public class LessonsController : Controller
    {
        private readonly ILessons _repositoryService;
        private readonly IToastNotification _toastNotification;
        private readonly UsersDbContext _context;
        public LessonsController(UsersDbContext context, ILessons repository,IToastNotification toastNotification)
        {
            _repositoryService = repository;
            _toastNotification = toastNotification;
            _context = context;
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



        public  IActionResult Create()
        {
            var lessonCreateViewModel = new LessonCreateViewModel();
            lessonCreateViewModel.Lesson = new LessonsDto();
            lessonCreateViewModel.Courses = _context.Courses.ToList();
            if (lessonCreateViewModel.Courses.Count == 0)
            {
                _toastNotification.AddErrorToastMessage("You need first create course ");
                return RedirectToAction(nameof(Index)); 
            }
            return View(lessonCreateViewModel);
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(LessonCreateViewModel data)
        {
            try
            {
                var validator = new LessonValidator();
                var validationResult = await validator.ValidateAsync(data.Lesson);
                if (!validationResult.IsValid)
                {
                    foreach (var error in validationResult.Errors)
                    {
                        _toastNotification.AddErrorToastMessage(error.ErrorMessage);
                    }
                    data.Courses = await _context.Courses.ToListAsync();
                    return View(data);
                }
                await _repositoryService.Add(data.Lesson);
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
                var lessonCreateViewModel = new LessonCreateViewModel();
                lessonCreateViewModel.Lesson = data;
                lessonCreateViewModel.Courses = _context.Courses.ToList();
               if (data == null) return NotFound();
                return View(lessonCreateViewModel);
            }
            catch (Exception ex)
            {
                return BadRequest(new { Message = ex.Message });
            }
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> EditConiform(Guid id, LessonCreateViewModel data)
        {
            try
            {
                var updatedData = await _repositoryService.Update(data.Lesson);
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
