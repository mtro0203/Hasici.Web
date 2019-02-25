using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class UserPanelViewModel
    {
        /// <summary>
        /// Name of logged in user
        /// </summary>
        public string RealName { get; set; }

        /// <summary>
        /// The flag if user is logged in
        /// </summary>
        public bool LoggedIn { get; set; }

        /// <summary>
        /// The id of logged in user
        /// </summary>
        public string UserId { get; set; }

    }
}
