using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using OnlineShop.Models;

namespace OnlineShop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signintManager;

        public AccountController(UserManager<ApplicationUser> userManager,SignInManager<ApplicationUser> signintManager)
        {
            _userManager = userManager;   
            _signintManager = signintManager;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Register()
        {

            return View();  
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (ModelState.IsValid)
            {

                var user = new ApplicationUser { UserName = model.Email, Email = model.Email }; 

                var result = await _userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    await _signintManager.SignInAsync(user, isPersistent: false);

                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(model);
        }

        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> Login(LogInModel user)
        {
            if (ModelState.IsValid)
            {
                var result = await _signintManager.PasswordSignInAsync(user.Email, user.Password, user.RememberMe, false);

                if (result.Succeeded)
                {
                    return RedirectToAction("Index", "Movies");
                }

                ModelState.AddModelError(string.Empty, "Invalid Login Attempt");

            }
            return View(user);

        

        }
        public async Task<IActionResult> Logout()
        {
            await _signintManager.SignOutAsync();

            return RedirectToAction("Index");
        }

        public void AddRole()
        {
            
        }



      






    }
}
  