using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using WebApp.Models;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class DeleteController : Controller
    {
        private readonly IRedisRepositoryBase _redisRepository;

        public DeleteController(IRedisRepositoryBase redisRepository)
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
                    if (_redisRepository.Exists(viewModel.KeyToDelete))
                    {
                        _redisRepository.Delete(viewModel.KeyToDelete);

                        new SetTempDataMessage()
                            .Display(TempData, "OK", $"The key {viewModel.KeyToDelete} has been removed.");
                    }
                    else
                    {
                        new SetTempDataMessage()
                            .Display(TempData, "Warning", $"Key {viewModel.KeyToDelete} was not found.", SetTempDataMessage.CssClassNameEnum.alert_warning);
                    }
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