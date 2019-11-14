﻿using System;
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

        public IActionResult LoginPage(IdentityError error)
        {
            User user = new User();
            user.Errors = new List<IdentityError>() { error };
            return View(user);
        }

        public IActionResult Register()
        {
            User user = new User();
            return View("LoginPage", user);
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        private bool IsNullOrEmpty(string stringValue)
        {
            if(stringValue == null || stringValue.Trim() == "")
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [HttpPost]
        public async Task<IActionResult> RegisterNewUserAsync(User user)
        {
            var newUser = new ApplicationUser() { UserName = user.Username, FirstName = user.FirstName, LastName = user.LastName, Email = user.Email };
            IdentityResult result;
            if (newUser != null)
            {
                List<IdentityError> errorList = new List<IdentityError>();
                if (IsNullOrEmpty(newUser.Email)) { errorList.Add(new IdentityError() { Description = "No Email Provided" }); }
                if (IsNullOrEmpty(newUser.UserName)) { errorList.Add(new IdentityError() { Description = "No Username Provided" }); }
                if (IsNullOrEmpty(newUser.LastName)) { errorList.Add(new IdentityError() { Description = "No Last Name Provided" }); }
                if (IsNullOrEmpty(newUser.FirstName)) { errorList.Add(new IdentityError() { Description = "No First Name Provided" }); }
                if (IsNullOrEmpty(user.Password)) { errorList.Add(new IdentityError() { Description = "No Password Provided" }); }


                if (errorList.Count() <= 0)
                {
                    result = await _userManager.CreateAsync(newUser, user.Password);
                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                        return View("LoginPage", new User() { Errors = result.Errors });
                    }
                }
                else
                {
                    return View("LoginPage", new User() { Errors = errorList });
                }
            }
            else
            {
                return View("LoginPage", new User() { Errors = new List<IdentityError>() { new IdentityError() { Description = "Error Attempting To Create New User Try Again Later" } } });
            }
        }


        [HttpPost]
        public async Task<IActionResult> Login(User user)
        {
          if(IsNullOrEmpty(user.Username) || IsNullOrEmpty(user.Password))
            {
                return View("Login", new User() { Errors = new List<IdentityError> { new IdentityError() { Code = "Must include username and password" } } });
            }
            var signInResult = await _signInManager.PasswordSignInAsync(user.Username, user.Password, true, false);
            if (signInResult.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }
            else
            {
                return View("Login", new User() { Errors = new List<IdentityError> { new IdentityError() { Code = "Invalid Username or password" } } });
            }

        }
    }
}