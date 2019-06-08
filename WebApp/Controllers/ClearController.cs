using Microsoft.AspNetCore.Mvc;
using RedisRepository.Interfaces;
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
            _redisRepository.Clear();

            new SetTempDataMessage()
                .Display(TempData, "OK", "Data cleared.");

            return View("Index");
        }
    }
}