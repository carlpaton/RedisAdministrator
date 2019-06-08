using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class DeleteController : Controller
    {
        private readonly IRedisRepository _redisRepository;

        public DeleteController(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Index(DeleteViewModel viewModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _redisRepository.Delete(viewModel.IdToDelete);

                    new SetTempDataMessage()
                        .Display(TempData, "OK", $"The id {viewModel.IdToDelete} has been removed.");
                }
            }
            catch (Exception ex)
            {
                new SetTempDataMessage()
                    .Display(TempData, "Error", ex.Message, SetTempDataMessage.CssClassNameEnum.alert_danger);
            }

            return View(viewModel);
        }
    }
}