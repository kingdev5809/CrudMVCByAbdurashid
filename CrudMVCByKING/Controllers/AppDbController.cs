using System;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using CrudMVCByKING.Models;
using CrudMVCByKING.Services.Repository;
using Microsoft.AspNetCore.Identity;


namespace CrudMVCByKING.Controllers
{
    [Authorize]
    public class AppDbController<TDto, TRepository> : Controller
        where TDto : class, IEntityDto
        where TRepository : IRepositoryService<TDto>

    {
        private readonly IRepositoryService<TDto> _repositoryService;
        private readonly UserManager<ApplicationUser> _userManager;
        public AppDbController(IRepositoryService<TDto> repository, UserManager<ApplicationUser> userManager)
        {
            _repositoryService = repository;
            _userManager = userManager;

        }


        public async Task<IActionResult> Index()
        {
            var data =  await _repositoryService.GetAll();
            Console.WriteLine(data);
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


  
        public IActionResult Create()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(TDto data)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    var user = await _userManager.GetUserAsync(HttpContext.User);
                    await _repositoryService.CreateAudit(data, "Create", user);
                    await _repositoryService.Add(data);

                    return RedirectToAction(nameof(Index));
                }
                return View(data);  
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
        public async Task<IActionResult> Edit(Guid id, TDto data)
        {
            try
            {
                if (id != data.Id)
                {
                    return BadRequest();
                }

                var user = await _userManager.GetUserAsync(HttpContext.User);
                await _repositoryService.CreateAudit(data, "Update", user);
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
                var user = await _userManager.GetUserAsync(HttpContext.User);
                var data =  await _repositoryService.Delete(id);
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
