using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebApp1.BLogicLayer.ViewModels;
using WebApp1.DAL.Entities;
using WebApp1.PresentationLayer.Filters;

namespace WebApp1.PresentationLayer.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(
            UserManager<User> userManager,
            SignInManager<User> signInManager,
            RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterVm vm)
        {
            if (!await _roleManager.RoleExistsAsync("Admin"))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole("Admin"));
            }

            if (!await _roleManager.RoleExistsAsync("User"))
            {
                await _roleManager.CreateAsync(
                    new IdentityRole("User"));
            }

            if (ModelState.IsValid)
            {
                var user = new User
                {
                    Email = vm.Email,
                    UserName = vm.UserName
                };

                var result =
                    await _userManager.CreateAsync(
                        user,
                        vm.Password!);

                if (result.Succeeded)
                {
                    if (vm.Email == "itzbaraapmc@gmail.com")
                    {
                        await _userManager.AddToRoleAsync(
                            user,
                            "Admin");
                    }
                    else
                    {
                        await _userManager.AddToRoleAsync(
                            user,
                            "User");
                    }

                    return RedirectToAction("Login");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(
                        error.Code,
                        error.Description);
                }
            }

            return View(vm);
        }

        [AllowAnonymousOnly]
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [AllowAnonymousOnly]
        [HttpPost]
        public async Task<IActionResult> Login(LoginVm vm)
        {
            if (ModelState.IsValid)
            {
                var result =
                    await _signInManager
                        .PasswordSignInAsync(
                            vm.UserName!,
                            vm.Password!,
                            vm.RememberMe,
                            false);

                if (result.Succeeded)
                {
                    return RedirectToAction(
                        "Index",
                        "Home");
                }

                ModelState.AddModelError(
                    "",
                    "Invalid login.");
            }

            return View(vm);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToAction("Login");
        }
    }
}