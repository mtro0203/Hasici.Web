using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hasici.Web
{
    public class Article
    {
        /// <summary>
        /// Thi id of the article
        /// </summary>
        [Key]
        public int Id { get; set; }

        /// <summary>
        /// The title
        /// </summary>
        [Display(Name ="Nadpis")]
        [Required(ErrorMessage ="Zadajte nadpis")]
        [MaxLength(100,ErrorMessage ="Nadpis je príliš dlhý")]
        public string Title { get; set; }

        /// <summary>
        ///The content 
        /// </summary>
        [Display(Name = "Obsah")]
        [Required(ErrorMessage = "Zadajte obsah")]
        public string Content { get; set; }

        /// <summary>
        /// Takes the firsts 50 char from the content
        /// </summary>
        [Display(Name = "Náhľad")]
        public string Preview
        {
            get
            {
                if (Content.Length <= 150)
                    return Content;

                return Content.Substring(0, 150) + "...";
            }
        }


        /// <summary>
        /// The date when the article was released
        /// </summary>
        [Display(Name = "Dátum publikácie")]
        public DateTime Date { get; set; }

        /// <summary>
        /// The flag if the article was released or not
        /// </summary>
        [Display(Name ="Publikované")]
        public bool Publised { get; set; }
        

       

    }
}
