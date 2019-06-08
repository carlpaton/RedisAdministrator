using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SelectListViewModel
    {
        [Required]
        [Display(Name = "Search On Key")]
        public string SearchOnKey { get; set; }
        public string Result { get; set; }
        public int ResultCount { get; set; }
    }
}