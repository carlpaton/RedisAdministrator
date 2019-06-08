using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DeleteViewModel
    {
        [Required]
        [Display(Name = "Key to delete")]
        public string KeyToDelete { get; set; }
    }
}
