

using Microsoft.AspNetCore.Identity;

namespace Hasici.Web
{

    /// <summary>
    /// User for the application
    /// </summary>
    public class ApplicationUser : IdentityUser
    {
        public string RealName { get; set; }
    }
}
