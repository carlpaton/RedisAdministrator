using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
using System;
using WebApp.Services;

namespace WebApp.Controllers
{
    public class ClearController : Controller
    {
        private readonly IRedisRepositoryBase _redisRepository;

        public ClearController(IRedisRepositoryBase redisRepository)
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
                if (ModelState.IsValid)
                {
                    _redisRepository.Clear();

                    new SetTempDataMessage()
                        .Display(TempData, "OK", "Data cleared.");
                }
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