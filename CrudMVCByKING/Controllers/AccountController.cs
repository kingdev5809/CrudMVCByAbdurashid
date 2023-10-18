using CrudMVCByKING.Models;
using CrudMVCByKING.Models.DTOs;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace CrudMVCByKING.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly UserManager<ApplicationUser> _userManager;

        public AccountController(
            SignInManager<ApplicationUser> signInManager,
            UserManager<ApplicationUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                TempData["Error"] = "Wrong credentials. Please try again";
                return View(model);
            }

            var user = await _userManager.FindByEmailAsync(model.Email);
                if (user == null )
                {
                TempData["Error"] = "User not found. Please try again";
                return View(model);
                }

            var checkPassword = await _userManager.CheckPasswordAsync(user, model.Password);
                    if (!checkPassword)
                    {
                        TempData["Error"] = "Wrong Password. Please try again";
                        return View(model);
                    }
                    var result = await _signInManager.PasswordSignInAsync(user, model.Password, false, false);
                    if (!result.Succeeded)
                    {
                        TempData["Error"] = "Wrong credentials. Please try again";
                        return View(model);
                    }
            return RedirectToAction("Index", "Home");                       
        }

 

        [HttpGet]
        public IActionResult Register()
        {
            var response = new RegisterDto();
            return View(response);
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterDto registerDto)
        {
            if (!ModelState.IsValid) return View(registerDto);

            var user = await _userManager.FindByEmailAsync(registerDto.Email);
            
            if (user != null)
            {
                TempData["Error"] = "This email address is already in use";
                return View(registerDto);
            }

            var newUser = new ApplicationUser()
            {
                Email = registerDto.Email,
                UserName = registerDto.Name
            };
            var newUserResponse = await _userManager.CreateAsync(newUser, registerDto.Password);

            //if (newUserResponse.Succeeded)
            //    await _userManager.AddToRoleAsync(newUser, UserRoles.User);
            if (!newUserResponse.Succeeded)
            {
                var errorDescription = newUserResponse.Errors.FirstOrDefault()?.Description;
                TempData["Error"] = errorDescription;
                return View(registerDto);
            }
            return RedirectToAction("Login", "Account");

        }



        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Login", "Account");
        }

      


    }
}
