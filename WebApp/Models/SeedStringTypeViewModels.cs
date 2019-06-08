using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SeedStringTypeViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        [Required]
        [Display(Name = "Number of keys")]
        public int NumberOfKeys { get; set; }
    }
}
