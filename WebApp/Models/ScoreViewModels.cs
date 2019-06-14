using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ScoreViewModel
    {
        public double ScoreYearOne { get; set; }
        public double ScoreYear1970 { get; set; }

        [Required]
        [Display(Name = "Calc Score From")]
        public string UserInput { get; set; }

        public double ScoreFromUserInput { get; set; }
    }
}
