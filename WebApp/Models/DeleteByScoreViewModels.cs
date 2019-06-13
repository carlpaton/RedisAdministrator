using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class DeleteByScoreViewModel
    {
        [Required]
        [Display(Name = "A Score Of")]
        public int ScoreFilter { get; set; }

        [Required]
        [Display(Name = "Search On Key")]
        public string SearchOnKey { get; set; }

        [Display(Name = "Max Results")]
        public int MaxResults { get; set; }

        [Required]
        [Display(Name = "Score Field is")]
        public string ScoreField { get; set; }

        public string Result { get; set; }
        public int ResultCount { get; set; }
    }
}
