using Esty_Models;
using Etsy_DTO.Account;
using Etsy_DTO.LoginRequest;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Esty_Presentation.Controllers
{
    public class LoginController : Controller
    {
        private readonly UserManager<Customer> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly SignInManager<Customer> _signInManager;
        public LoginController(
                               UserManager<Customer> userManager,
                                RoleManager<IdentityRole> roleManager,
                                SignInManager<Customer> signInManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _signInManager = signInManager;
        }

        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            return View();
        }
        [HttpPost]
        [AllowAnonymous]
     
        public async Task<IActionResult> Index(LoginViewMode loginView)
        {
            if (ModelState.IsValid)
            {
                string s = loginView.Email;
                Customer? user = await _userManager.FindByEmailAsync(s);

                if (user != null)
                {
                    bool found = await _userManager.CheckPasswordAsync(user, loginView.Password);
                    if (found)
                    {
                        await _signInManager.SignInAsync(user, loginView.RememberMe);
                        return RedirectToAction("Index", "Category");
                    }
                }
                ModelState.AddModelError("", "username and password is error ");
            }
            return View(loginView);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index");
        }
    }
}
