using Microsoft.AspNetCore.Mvc;
using System;
using System.Globalization;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ScoreController : Controller
    {
        public IActionResult Index()
        {
            var viewModel = new ScoreViewModel()
            {
                ScoreYear1970 = ScoreCalculator.ScoreYear1970(),
                ScoreYearOne = ScoreCalculator.ScoreYearOne()
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
                    var userScore = ScoreCalculator.ScoreByDate(DateTime.ParseExact(viewModel.UserInput, "dd/MM/yyyy", new CultureInfo("en-NZ")));

                    new SetTempDataMessage()
                        .Display(TempData, "Score Result", $" will be {userScore}");
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