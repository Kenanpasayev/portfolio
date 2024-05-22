using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApplication15.Models;
using WebApplication15.ViewModels.Account;

namespace WebApplication15.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;

        public AccountController(UserManager<User>userManager)
        {
            _userManager = userManager;
        }
        public async Task<IActionResult> Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(RegisterVM registerVM)
        {
            User newUser = new User();
            {
                newUser.Name = registerVM.Name;
                newUser.Surname = registerVM.Surname;
                newUser.Email = registerVM.Email;
                newUser.UserName = registerVM.UserName;
            };
            if (!ModelState.IsValid) { return View(); };
            
            var result = await _userManager.CreateAsync(newUser, registerVM.Password);
            if (!result.Succeeded)
            {
                foreach (var item in result.Errors)
                {
                    ModelState.AddModelError("", item.Description);
                }
                return View();
            }
            return RedirectToAction("Index", "Home");

        }
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Login(LoginVM loginVM)
        {
            return View();
        }
    }
}
