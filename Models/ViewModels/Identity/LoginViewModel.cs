using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class LoginViewModel
    {

        /// <summary>
        /// User email
        /// </summary>
       [Required(ErrorMessage = "Zadajte platnu emailovú adresu")]
       [EmailAddress(ErrorMessage ="Zadajte platnu emailovú adresu")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše heslo")]
        [DataType(DataType.Password)]
        [Display(Name ="Heslo")]
        public string Password { get; set; }

    }
}
