using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class LoginViewModel
    {

        /// <summary>
        /// User email
        /// </summary>
       [Required]
       [EmailAddress(ErrorMessage ="Zadajte platnu emailovú adresu")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Heslo")]
        public string Password { get; set; }

    }
}
