
using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class ChangePasswordViewModel
    {
        /// <summary>
        /// User old password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše staré heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Vaše staré heslo")]
        public string OldPassword { get; set; }


        /// <summary>
        /// User new password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše nové heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Vaše nové heslo")]
        public string NewPassword { get; set; }

        /// <summary>
        /// User new password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše nové heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Vaše nové heslo")]
        [Compare(nameof(NewPassword), ErrorMessage = "Heslá sa musia zhodovať")]
        public string NewPassword2 { get; set; }
    }
}
