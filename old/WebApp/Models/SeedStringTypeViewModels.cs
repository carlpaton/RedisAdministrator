using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SeedStringTypeViewModel
    {
        [Required]
        [Display(Name = "Number of keys")]
        public int NumberOfKeys { get; set; }
    }
}
