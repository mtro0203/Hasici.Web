using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class RegisterViewModel
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required]
        [EmailAddress(ErrorMessage = "Zadajte platnu emailovú adresu")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }


        /// <summary>
        /// First name of the user 
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše meno")]
        [Display(Name = "Meno")]
        public string FirstName { get; set; }


        /// <summary>
        /// Last name of the user 
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše priezvisko")]
        [Display(Name = "Priezvisko")]
        public string LastName { get; set; }

    }
}
