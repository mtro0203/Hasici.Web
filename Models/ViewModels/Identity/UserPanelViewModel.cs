using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class UserPanelViewModel
    {
        /// <summary>
        /// Name of logged user
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// The flag if user is logged in
        /// </summary>
        public bool LoggedIn { get; set; }


    }
}
