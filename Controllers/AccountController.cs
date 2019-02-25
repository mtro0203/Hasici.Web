using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hasici.Web.Controllers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hasici.Web
{

    [Authorize]
    public class AccountController : Controller
    {

        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;


        #region Constructors

        /// <summary>
        /// Constructor with parameters injected by DI
        /// </summary>
        /// <param name="userManager">Manager included in framework, injected by DI</param>
        /// <param name="signInManager">Manager included in framework, injected by DI</param>
        public AccountController(UserManager<ApplicationUser> userManager
                                , SignInManager<ApplicationUser> signInManager)
        {
            this.userManager = userManager;
            this.signInManager = signInManager;
        }


        #endregion     
               

        
        #region LogIn,LogOut,Register,Change pass

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
        public async Task<IActionResult> Login(LoginViewModel loginViewModel, string returnURL = null)
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
            return RedirectToAction(nameof(HomeController.Index), "Home");
        }

        /// <summary>
        ///GET Method to register user
        /// </summary>
        /// <param name="returnURL"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Register(string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;

            var model = new RegisterViewModel();
            model.Sex = "M";
           
            return View(model);
        }

        /// <summary>
        /// POST Method to register user
        /// </summary>
        /// <param name="model"></param>
        /// <param name="returnURL"></param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model, string returnURL)
        {
            ViewData["ReturnUrl"] = returnURL;

            //if sends data are not ok
            if (!ModelState.IsValid)
                return View(model);

            //create new user
            var user = new ApplicationUser
            {
                UserName = model.Email,
                RealName = model.FirstName + " " + model.LastName,
                //if M true
                Male = model.Sex == "M" ? true : false,
                Email = model.Email
            };

            //adds user to db
            var result = await userManager.CreateAsync(user, model.Password);


            if (result.Succeeded)
            {
                await signInManager.SignInAsync(user, false);
                return RedirectToLocal(returnURL);
            }

            //ads errors and return view
            AddErrors(result);
            return View(model);

        }

        /// <summary>
        /// GET Method to change password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [Route("/change")]
        [HttpGet]
        public IActionResult ChangePassword()
        {

            ViewData["result"] = null;
            return View();
        }

        /// <summary>
        /// POST Method to change password
        /// </summary>
        /// <param name="model"></param>
        /// <returns></returns>
        [HttpPost]
        [Route("/change")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
           

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await userManager.GetUserAsync(User);

           var result = await userManager.ChangePasswordAsync(user, model.OldPassword, model.NewPassword);

            if(result.Succeeded)
            {
                ViewData["result"] = "Heslo bolo úspešne zmenené";
                return View(model);
            }
            ViewData["result"] = "Heslo sa nepodarilo zmeniť";
            return View(model);
        }

        #endregion


        #region ManageUsers

        /// <summary>
        /// GET Method to delete user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpGet]
        public async Task<IActionResult> Delete (string id)
        {

            var userToDele = await userManager.FindByIdAsync(id);


            return View(userToDele);
        }

        /// <summary>
        /// POST Method to delete user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        [HttpPost,ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
             

            //get user and try to delete them
            var userToDele = await userManager.FindByIdAsync(id);
                       

            var result = await userManager.DeleteAsync(userToDele);

            if(result.Succeeded)
                return RedirectToAction(nameof(AccountController.GetUsers), "Account");

            ModelState.AddModelError(String.Empty, "Nepodarilo sa zmazať užívateľa");
                return View();
        }


        /// <summary>
        /// Method to display profile of given user
        /// </summary>
        /// <param name="id">user id</param>
        /// <returns></returns>
        public async Task<IActionResult> Profile (string id)
        {
            var user = await userManager.FindByIdAsync(id);

            if(user.Male == true)
            {
                ViewData["Sex"] = "Muž";
            }

            else
            {
                ViewData["Sex"] = "Žena";
            }         

            return View(user);
        }


        /// <summary>
        /// Returns list of all users
        /// </summary>
        /// <returns></returns>
        public IActionResult GetUsers()
        {
            var listOfUsers = userManager.Users.ToList();

            return View(listOfUsers);
        }
               
        #endregion


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

        /// <summary>
        /// Helper method to add all errors
        /// </summary>
        /// <param name="result"></param>
        private void AddErrors(IdentityResult result)
        {
            foreach (var error in result.Errors)
                ModelState.AddModelError(string.Empty, error.Description);
        }
        #endregion

    }

   
}