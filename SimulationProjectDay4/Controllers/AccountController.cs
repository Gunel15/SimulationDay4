using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using SimulationProjectDay4.Enums;
using SimulationProjectDay4.Models;
using SimulationProjectDay4.ViewModels.Account;

namespace SimulationProjectDay4.Controllers
{
    public class AccountController(UserManager<User> _userManager,RoleManager<Role> _roleManager,SignInManager<User> _signInManager) : Controller
    {
        public IActionResult Register()
        {
            return View();
        }

        public async Task<IActionResult> Register(RegisterVM vm)
        {
            if (!ModelState.IsValid) 
                return View();
            User user = new()
            {
                FullName = vm.FullName,
                UserName = vm.Username,
                Email = vm.Email
            };
            var result=await _userManager.CreateAsync(user,vm.Password);
            if(!result.Succeeded)
            {
               foreach(var error in result.Errors)
                {
                    ModelState.AddModelError("",error.Description);
                }
               return View();
            }

            var roleResult = await _userManager.AddToRoleAsync(user, nameof(Roles.User));
            if(!roleResult.Succeeded)
            {
                foreach(var error in roleResult.Errors)
                {
                    ModelState.AddModelError("", error.Description);
                }
                await _userManager.DeleteAsync(user);
                return View();
            }
            return RedirectToAction(nameof(Login));
        }

        public async Task<IActionResult> Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(LoginVM vm)
        {

        }
    }
}
