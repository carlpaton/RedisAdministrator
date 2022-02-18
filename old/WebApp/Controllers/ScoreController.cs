using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ScoreController : Controller
    {
        private readonly IScoreCalculator _scoreCalculator;

        public ScoreController(IScoreCalculator scoreCalculator)
        {
            _scoreCalculator = scoreCalculator;
        }

        public IActionResult Index()
        {
            var viewModel = new ScoreViewModel()
            {
                ScoreYear1970 = _scoreCalculator.ScoreYear1970(),
                ScoreYearOne = _scoreCalculator.ScoreYearOne(),
                ScoreBaseDate = DateTime.Now
            };
            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Index(ScoreViewModel viewModel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (viewModel.UserInputDate != null)
                    { 
                        var userDate = DateTime.ParseExact(viewModel.UserInputDate, "dd/MM/yyyy", new CultureInfo("en-NZ"));
                        var userScore = _scoreCalculator.ScoreByDate(userDate);

                        new SetTempDataMessage()
                            .Display(TempData, "Score From Date", $" {viewModel.UserInputDate} will be {userScore}");
                    } 

                    if (viewModel.UserInputDouble != null)
                    {
                        if (double.TryParse(viewModel.UserInputDouble, out double d))
                        {
                            var userDate = _scoreCalculator.DateByScore(d);

                            new SetTempDataMessage()
                                .Display(TempData, "Date From Score", $" {viewModel.UserInputDouble} will be {userDate.ToString("dd/MM/yyyy")}", append: true);
                        }
                    } 

                    viewModel.ScoreYear1970 = _scoreCalculator.ScoreYear1970();
                    viewModel.ScoreYearOne = _scoreCalculator.ScoreYearOne();
                    viewModel.ScoreBaseDate = DateTime.Now;
                }
                catch (Exception ex)
                {
                    new SetTempDataMessage()
                        .Display(TempData, "Well thats some bullshit right there!", ex.Message, SetTempDataMessage.CssClassNameEnum.alert_danger);
                }
            }

            return View(viewModel);
        }
    }
}