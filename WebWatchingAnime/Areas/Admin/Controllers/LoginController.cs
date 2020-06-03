using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using WebWatchingAnime.Data.Entities;
using WebWatchingAnime.ViewModel.ViewModel.Account;

namespace WebWatchingAnime.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class LoginController : Controller
    {

        UserManager<AppUser> _userManager;
        SignInManager<AppUser> _signInManager;
        public LoginController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }
        [AllowAnonymous]
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Authen(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var result = await _signInManager.PasswordSignInAsync(model.UserName, model.Password, model.RememberMe, lockoutOnFailure: false);
                if (result.Succeeded)
                {
                    //HttpContext.User = model.UserName;
                    return new OkObjectResult(new { Success = true, Data = model });
                }
                if (result.IsLockedOut)
                {
                    return new ObjectResult(new { Success = false, Data = "Tài khoản bị khóa" });
                }
                else
                {
                    return new ObjectResult(new { Success = false, Data = "Đăng nhập thất bại" });
                }
            }
            return new ObjectResult(new { Success = false, Data = model });
        }


        [HttpGet]
        public async Task<ActionResult> ResetPasswordAsync()
        {
            System.Security.Claims.ClaimsPrincipal currentUser = this.User;
            var user = await _userManager.GetUserAsync(HttpContext.User);
            ViewData["username"] = user.UserName;
            //  return View(user.UserName);
            return View();
        }

        [HttpPost]
        //[Route("logout.html")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel vm)
        {
            var user = await _userManager.GetUserAsync(HttpContext.User);
            var user_newpas = await _userManager.ChangePasswordAsync(user, vm.OldPassword, vm.NewPassword);
            return new ObjectResult(user_newpas);
        }

        [HttpGet]
        //[Route("logout.html")]
        //[ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction(nameof(LoginController.Index));
        }



        [HttpGet]
        [AllowAnonymous]
        // [Route("register.html")]
        public IActionResult Register()
        {
            //ViewData["ReturnUrl"] = returnUrl;
            return View();
        }

        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        //[Route("register.html")]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {

            if (!ModelState.IsValid)
            {
                return View(model);
            }
            //MM/dd/yyy]
            var user = new AppUser
            {
                UserName = model.Email,
                Email = model.Email,
                FullName = model.FullName,
                LockoutEnabled = true,
                Status = true

            };
            var result = await _userManager.CreateAsync(user, model.Password);
            if (result.Succeeded)
            {
                //return RedirectToAction(nameof(LoginController.Index));
                return new OkObjectResult(new { Success = true, Data = "Đăng kí thành công, liên hệ Admin để được cấp quyền" });
            }

            // If we got this far, something failed, redisplay form
            return BadRequest();
        }
    }
}


