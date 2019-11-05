using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc;
using MindOverMatter.Models.DbContexts;
using MindOverMatter.Models.Identity;
using MindOverMatter.Models.User;

namespace MindOverMatter.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Login(bool isInvalid = false)
        {
            User user = new User();
            user.IsInvalid = isInvalid;
            return View(user);
        }

        public IActionResult Register()
        {
            return View();
        }

        public IActionResult SignOut()
        {
            // var authenticationManager = HttpContext.Current.GetOwinContext().Authentication;
            // authenticationManager.SignOut();

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public async Task<IActionResult> RegisterNewUserAsync(User user)
        {
            var newUser = new ApplicationUser() { UserName = user.Username, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
            IdentityResult result = await _userManager.CreateAsync(newUser, user.Password);

            return RedirectToAction("Index", "Home");
        }

        [HttpPost]
        public IActionResult LoginUser(User user)
        {
            var appUser = new ApplicationUser() { UserName = user.Username, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
            var test = _signInManager.PasswordSignInAsync(appUser,user.Password,false,false);

            if (User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "~/Controllers/Home");
            }
            else
            {
                return View("Login", new User() { IsInvalid = true });
            }
            
        }
    }
}