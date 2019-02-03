using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasici.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Hasici.Web
{
    //TODO: OKOMENTOVAT KOD!!!!

    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        /// <summary>
        /// Constructor with parameters injected by DI
        /// </summary>
        /// <param name="userManager">Manager included in framework, injected by DI</param>
        /// <param name="signInManager">Manager included in framework, injected by DI</param>
        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }

        /// <summary>
        /// Method to get login page
        /// </summary>
        /// <param name="returnURL"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login(string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;
            return View();
        }

        /// <summary>
        /// Method which sends data to server from login form
        /// </summary>
        /// <param name="loginViewModel">View model of login page</param>
        /// <param name="returnURL"></param>
        /// <returns></returns>
        [HttpPost]
        [AllowAnonymous]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel,string returnURL = null)
        {

            
            ViewData["returnUrl"] = returnURL;

            //if data are not ok
            if (!ModelState.IsValid)
                return View(loginViewModel);
            
            //trying to sign in user
            var result = await signInManager.PasswordSignInAsync(loginViewModel.Email, loginViewModel.Password, false, false);


   
            // if sign in failed
            if (!result.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Neplatné prihlasovacie údaje.");
                return View(loginViewModel);
            }

            return RedirectToLocal(returnURL);
        }
        /// <summary>
        /// Method to LogOut user
        /// </summary>
        /// <returns></returns>
        public async Task<IActionResult> LogOut()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction(nameof(HomeController.Index),"Home");
        }


        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register (string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;
            return View();
        }


        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register (RegisterViewModel model,string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;

            //if sends data are not ok
            if (!ModelState.IsValid)
                return View(model);
            
            //create new user
            var user = new ApplicationUser { UserName = model.Email,
                                             RealName = model.FirstName + " " + model.LastName,
                                             Email = model.Email };

            //adds user to db
                var result = await userManager.CreateAsync(user, model.Password);

            //TODO: dokoncit presmerovanie  + osetrenie chyb
            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToLocal(returnURL);
            }

            return Content("dojebalo se to");

        }


        #region Helpers

        /// <summary>
        /// Helper method to redirecting
        /// </summary>
        /// <param name="returnUrl"></param>
        /// <returns></returns>
        private IActionResult RedirectToLocal(string returnUrl)
        {
            return Url.IsLocalUrl(returnUrl)
                ? Redirect(returnUrl)
                : (IActionResult)RedirectToAction(nameof(HomeController.Index), "Home");
        }


        #endregion

    }
}