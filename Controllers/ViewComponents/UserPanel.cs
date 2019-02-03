using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Hasici.Web
{
    public class UserPanel : ViewComponent
    {
        private readonly UserManager<ApplicationUser> _userManager;

        /// <summary>
        /// Constructor with userManager parameter, which is injected by DI
        /// </summary>
        /// <param name="userManager"></param>
        public UserPanel(UserManager<ApplicationUser> userManager)
        {
            _userManager = userManager;
        }

        //TODO: osetrit padanie pri neprihlasenom userovi

        public async Task<IViewComponentResult> InvokeAsync()
        {

            //getting the flag if user is logged in
            bool loggedIn = HttpContext.User.Identity.IsAuthenticated;

            //if logged in
            if (loggedIn)
            {
                //get currentlly logged in user
                var appUser = await _userManager.FindByNameAsync(HttpContext.User.Identity.Name);

                var vm = new UserPanelViewModel
                {
                    RealName = appUser.RealName,
                    LoggedIn = true
                    //TODO: pridat do viewmodelu ostatne vlastnosti       

                };

                return View(vm);
            }

            else
            {
                var vm = new UserPanelViewModel
                {
                    LoggedIn = false
                };

                return View(vm);
            }
           
        }




    }
}

