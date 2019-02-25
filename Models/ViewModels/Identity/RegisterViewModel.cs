using Microsoft.AspNetCore.Mvc.Rendering;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Hasici.Web
{
    public class RegisterViewModel
    {
        /// <summary>
        /// User email
        /// </summary>
        [Required(ErrorMessage = "Zadajte váš email")]
        [EmailAddress(ErrorMessage = "Zadajte platnú emailovú adresu")]
        public string Email { get; set; }

        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        public string Password { get; set; }


        /// <summary>
        /// User password
        /// </summary>
        [Required(ErrorMessage = "Zadajte vaše heslo")]
        [DataType(DataType.Password)]
        [Display(Name = "Heslo")]
        [Compare(nameof(Password),ErrorMessage ="Heslá sa musia zhodovať")]
        public string Password2 { get; set; }
       


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


        /// <summary>
        /// Sex of the user
        /// </summary>
        [Display(Name = "Pohlavie")]
        public string Sex { get; set; }
    
        /// <summary>
        /// List of sexs
        /// </summary>
        public List<SelectListItem> Sexs { get; } = new List<SelectListItem>
        {
            new SelectListItem {Value = "M", Text= "Muž"},
            new SelectListItem {Value = "F", Text= "Žena"}
        };

       
    }
}
