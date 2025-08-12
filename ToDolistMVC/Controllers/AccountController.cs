using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ToDolistMVC.ViewModels;

namespace ToDolistMVC.Controllers
{
    public class AccountController : Controller
    {
        SignInManager<IdentityUser> _signInManager;
        UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> _signInManager,
            UserManager<IdentityUser> _userManager)
        {
                this._signInManager = _signInManager; 
                this._userManager = _userManager;
        }

        [Route("/Login")]
        [Route("/Account/Login")]
        public IActionResult Login(string returnUrl = null)
        {
            LoginViewModel model = new LoginViewModel();
            model.returnUrl = returnUrl;
            return View();
        }

        [Route("/Signup")]
        public IActionResult Signup()
        {
            return View();
        }


        [Route("/Login")]
        [Route("/Account/Login")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Return the same view with the invalid model to show validation errors
                return View("Login", model);
            }

            // Login Action
            var result = await _signInManager.PasswordSignInAsync(model.Email, model.Password, false, false);
            if (result.Succeeded)
                return string.IsNullOrEmpty(model.returnUrl)? RedirectToAction("Index", "Task"):Redirect(model.returnUrl);
            return View("Login", model);
        }

        [Route("/Signup")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Signup(SignupViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Return the same view with the invalid model to show validation errors
                return View("Signup", model);
            }

            // Register Action
            var user = new IdentityUser { UserName = model.Email, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (!result.Succeeded)
                return View("Signup", model);

            await _signInManager.SignInAsync(user, isPersistent: false);
            return RedirectToAction("Index", "Task");
        }


        [Route("/Logout")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return Redirect("/");
        }

    }
}
