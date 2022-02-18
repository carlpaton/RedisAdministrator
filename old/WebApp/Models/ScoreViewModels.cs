using System;
using System.ComponentModel.DataAnnotations;

namespace WebApp.Models
{
    public class ScoreViewModel
    {
        [Display(Name = "01/01/0001")]
        public double ScoreYearOne { get; set; }

        [Display(Name = "01/01/1970")]
        public double ScoreYear1970 { get; set; }

        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy hh:mm:sss}")]
        [Display(Name = "Calculated On")]
        public DateTime ScoreBaseDate { get; set; }

        [Display(Name = "Score From Date")]
        public string UserInputDate { get; set; }

        [Display(Name = "Date From Score")]
        public string UserInputDouble { get; set; }

        public double ScoreFromUserInput { get; set; }

    }
}
