using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCByKING.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;

        public HomeController(
       
            UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Index()
        {
            var user = await _userManager.GetUserAsync(User);

            if (user == null)
            {
                // Handle the case where the user is not authenticated or not found
                return RedirectToAction("Login");
            }

            var userProfile = new UserProfileViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email
            };

            return View(userProfile);
        }
      
    }
}
