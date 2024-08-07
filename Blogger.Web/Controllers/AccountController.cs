﻿using Blogger.Web.Models.ViewModel;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Blogger.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<IdentityUser> userManager;
        private readonly SignInManager<IdentityUser> signInManager;

        public AccountController(UserManager<IdentityUser>userManager, SignInManager<IdentityUser>signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel registerViewModel) 
        {
            var identityUser = new IdentityUser
            { 
                UserName = registerViewModel.Username,
                Email = registerViewModel.Email,
                          
            };
            var identityResult = await userManager.CreateAsync(identityUser, registerViewModel.Password);
            if (identityResult.Succeeded) 
            {
                //role assignment

                var roleResult =await userManager.AddToRoleAsync(identityUser, "User");

                if (roleResult.Succeeded) 
                {
                    //success
                    return RedirectToAction("Register");
                }
            }
            return View();

        }


        [HttpGet]

        public IActionResult Login() 
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LogInViewModel logInViewModel)
        {
            var signInResult =await signInManager.PasswordSignInAsync(logInViewModel.Username, logInViewModel.Password, false, false);
            if (signInResult.Succeeded) 
            {
                return RedirectToAction("Index", "Home");
            }
            ModelState.AddModelError(string.Empty, "Invalid login attempt.");
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");

        }
        [HttpGet]
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
