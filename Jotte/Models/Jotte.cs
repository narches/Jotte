using System.ComponentModel.DataAnnotations;

namespace Jotte.Models
{
    public class Sjotte
    {

        public int Id { get; set; }


        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Date")]
        public DateTime Date { get; set; }
        
        [Display(Name = "Scripture\u00A0Studied")]
        public string? Scripture { get; set; }

        public string? Note { get; set; }
    }
}
