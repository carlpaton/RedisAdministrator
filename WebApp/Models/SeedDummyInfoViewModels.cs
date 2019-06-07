using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class SeedDummyInfoViewModel
    {
        public string Key { get; set; }
        public string Value { get; set; }

        [Required]
        [Display(Name="Number of `Sets`")]
        public int KeyCount { get; set; }

        [Required]
        [Display(Name="Number of values")]
        public int ValueCount { get; set; }
    }
}
