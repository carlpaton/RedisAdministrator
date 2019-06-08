using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ClearController : Controller
    {
        private readonly IRedisRepository _redisRepository;

        public ClearController(IRedisRepository redisRepository)
        {
            _redisRepository = redisRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Clear()
        {
            try
            {
                _redisRepository.Clear();

                new SetTempDataMessage()
                    .Display(TempData, "OK", "Data cleared.");
            }
            catch (Exception ex)
            {
                new SetTempDataMessage()
                    .Display(TempData, "Error", ex.Message, SetTempDataMessage.CssClassNameEnum.alert_danger);
            }

            return View("Index");
        }
    }
}