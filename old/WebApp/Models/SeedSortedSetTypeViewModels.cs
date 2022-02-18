using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SeedSortedSetTypeViewModel
    {
        [Required]
        [Display(Name = "Number of keys")]
        public int NumberOfKeys { get; set; }

        [Required]
        [Display(Name = "Number of values in key")]
        public int NumberOfValuesInKey { get; set; }
    }
}
